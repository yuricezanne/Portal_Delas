using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace SuaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<UserInfo> users = new List<UserInfo>
        {
            new UserInfo
            {
                UserInfoId = 1,
                Email = "usuario1@example.com",
                Password = "senha123",
                Name = "Usuário 1",
                UserType = "Tipo 1",
                CompanyName = "Empresa 1",
                UserPhone = "123456789"
            },
            new UserInfo
            {
                UserInfoId = 2,
                Email = "usuario2@example.com",
                Password = "senha456",
                Name = "Usuário 2",
                UserType = "Tipo 2",
                CompanyName = null,
                UserPhone = "987654321"
            }
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = users.Find(u => u.UserInfoId == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserInfo user)
        {
            user.UserInfoId = users.Count + 1;
            users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.UserInfoId }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserInfo user)
        {
            var existingUser = users.Find(u => u.UserInfoId == id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Name = user.Name;
            existingUser.UserType = user.UserType;
            existingUser.CompanyName = user.CompanyName;
            existingUser.UserPhone = user.UserPhone;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.Find(u => u.UserInfoId == id);
            if (user == null)
            {
                return NotFound();
            }

            users.Remove(user);
            return NoContent();
        }
    }
}