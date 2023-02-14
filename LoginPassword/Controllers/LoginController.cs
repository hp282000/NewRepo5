using LoginPassword.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace LoginPassword.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ContextClass _context;

        public LoginController(ContextClass context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var display = _context.Logins.ToListAsync();

            return Ok(display);
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginView loginview)
        {
            Login login = new Login();

            login.UserName = loginview.UserName;

            //user input in byte 
            var password = Encoding.ASCII.GetBytes(loginview.Password);

            login.Password = password;

            var hsa = new HMACSHA256();
            login.KeyPassword = hsa.Key;

            _context.Logins.Add(login);

            await _context.SaveChangesAsync();

            return Ok(login);
        }

        [HttpPost("Check")]

        public async Task<IActionResult> Check(LoginView loginview)
        {


            //user input in byte 

            var password = Encoding.ASCII.GetBytes(loginview.Password);

            var hsa = new HMACSHA256();
            var loginviewkey = hsa.Key;

            var pass = _context.Logins.FirstOrDefault(x => x.UserName == loginview.UserName);

            //check password and database password 
            
            var match = password.Equals(pass.Password);

               if (match  == true)
            {
                return Ok("Hey :" + loginview.UserName);
            }
            else
            {
                return NotFound("User Not Found");
            }

            _context.Logins.Add(pass);
            await _context.SaveChangesAsync();

            return Ok(loginview);
        }
    }
}
