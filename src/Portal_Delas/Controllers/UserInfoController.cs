using Core.Data;
using Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace UI.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly PortalDbContext _context;
        private readonly Gateway _gateway;

        private ILogger<PortalDbContext> _logger { get; set; }

        private readonly string _jwtSecretKey = "MinhaSenhaUltraSecreta1234567890!";

        public UserInfoController(PortalDbContext context, Gateway gateway, ILogger<UserInfoController> logger)
        {
            _gateway = gateway;
            _context = context;
            _logger = (ILogger<PortalDbContext>?)logger;
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
                ModelState.AddModelError(string.Empty, "Dados de registo inválidos");
                _logger.LogInformation("Erro: Dados de registo inválidos!");
                return View();
            }

            bool accountAlreadyExists = CheckIfAccountExists(registration);

            if (accountAlreadyExists)
            {
                ModelState.AddModelError(string.Empty, "Usuário já existente.");
                _logger.LogInformation("Erro: Usuário " + "(" + registration.Email + ")" + " já existente!");
                return View();
            }

            _gateway.RegisterUser(registration);

            try
            {
                _logger.LogInformation("Usuário " + "(" + registration.Email + ")" + " registado com sucesso!");
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
        public async Task<IActionResult> Login([FromForm] UserInfo login)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Dados de login inválidos");
                _logger.LogInformation("Erro: Dados de login inválidos!");
                return View();
            }

            UserInfo userLogin = _gateway.AuthenticateUser(login.Email, login.Password);

            if (userLogin == null)
            {
                ModelState.AddModelError(string.Empty, "Conta não encontrada. Por favor, tente com outra conta ou registre-se.");
                _logger.LogInformation("Erro: Conta " + "(" + login.Email + ")" + " não encontrada!");
                return View();
            }
            else if (userLogin.Password != login.Password)
            {
                ModelState.AddModelError(string.Empty, "Senha incorreta. Por favor, tente novamente.");
                _logger.LogInformation("Erro: Senha incorreta!");
                return View();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Email, userLogin.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            var id = userLogin.UserInfoId;
            if (userLogin.Name != null)
            {
                var name = userLogin.Name;
                HttpContext.Session.SetString("name", name);
            }
            var email = userLogin.Email;


            HttpContext.Session.SetString("token", tokenString);
            HttpContext.Session.SetInt32("UserId", id);
            HttpContext.Session.SetString("email", email);

            _logger.LogInformation("Login " + "(" + login.Email + ")" + " efetuado com sucesso!");
            return RedirectToAction("Index", "Todo");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("name");

            _logger.LogInformation("Logout efetuado com sucesso!");
            return RedirectToAction("Login", "UserInfo");
        }
    }
}
