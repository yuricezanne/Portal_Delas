using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UI.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly PortalDbContext _context;
        private readonly Gateway _gateway;

        private readonly string _jwtSecretKey = "MinhaSenhaUltraSecreta1234567890!";

        public UserInfoController(PortalDbContext context, Gateway gateway)
        {
            _gateway = gateway;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] UserInfo registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool accountAlreadyExists = CheckIfAccountExists(registration);

            if (accountAlreadyExists)
            {
                ModelState.AddModelError(string.Empty, "User already exists.");
                return View();
            }

            _gateway.RegisterUser(registration);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Login", "UserInfo");
            }

            return RedirectToAction("Login", "UserInfo");
        }

        private bool CheckIfAccountExists(UserInfo registration)
        {
            var existingAccount = _gateway.VerifyUser(registration);

            return existingAccount != null;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] UserLoginInfo login)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login");
                return View();
            }

            UserInfo userLogin = _gateway.AuthenticateUser(login.Email, login.Password);

            if (userLogin == null)
            {
                ModelState.AddModelError(string.Empty, "Account not found. Please try again.");
                return View();
            }
            else if (userLogin.Password != login.Password)
            {
                ModelState.AddModelError(string.Empty, "Incorrect password. Please try again.");
                return View();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userLogin.Email),
                    new Claim(ClaimTypes.Name, userLogin.Name)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            var id = userLogin.UserInfoId;

            HttpContext.Session.SetString("token", tokenString);
            HttpContext.Session.SetInt32("UserId", id);

            Console.WriteLine($"Email: {userLogin.Email}");
            Console.WriteLine($"Name: {userLogin.Name}");

            ViewBag.UserName = userLogin.Name;
            ViewBag.UserEmail = userLogin.Email;

            Console.WriteLine($"Email: {userLogin.Email}");
            Console.WriteLine($"Name: {userLogin.Name}");

            var principal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, userLogin.Email),
                new Claim(ClaimTypes.Name, userLogin.Name),
            }));

            //return RedirectToAction("Index", "Home");
            return View("../Home/Index", new LoginResultModel
            {
                LoginType = userLogin.UserType
            });
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            HttpContext.Session.Remove("UserId");

            return RedirectToAction("Login", "UserInfo");
        }     
    }
}