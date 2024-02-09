using BidNest_Library.Interfaces;
using BidNest_Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging.Signing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BidNest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BidNestContext _context;
        private IConfiguration _config;
        private IServices _services;
        public LoginController(BidNestContext context, IConfiguration config ,IServices services)
        {
            _context = context;
            _config = config;
            _services = services;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserLogin request)
        {
            try
            {
                var user = Authenticate(request);
                if (user != null) {
                    var Token = GenerateToken(user);
                    var User = new { 
                        token = Token,
                        username = user.Username,
                        role = user.Role
                    };
                    return Ok(User);
                }
                return NotFound("User Not found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Server error {ex.Message}");
            }
        }

        private User Authenticate(UserLogin user)
        {
            var CurrentUser = _context.Users.FirstOrDefault(u => u.Username == user.UserName &&  u.Password == user.Password);
            if(CurrentUser != null)
            {
                return CurrentUser;
            }
            return null;
        }
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                  new Claim(ClaimTypes.SerialNumber,Convert.ToString(user.UserId)),
                  new Claim(ClaimTypes.Role,user.Role),
                  new Claim(ClaimTypes.Email,user.Email)
            };
            var Token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
                expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        [HttpPost, Route("SendEmail")]
        public async Task<string> SendEmailAsync(Email email)
        {
            string message = await _services.SendEmailAsync(email);
            return message;
        }

    }
}
