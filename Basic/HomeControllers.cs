using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Basic
{
    [Route("[action]")]
    [ApiController]
    public class HomeControllers : Controller
    { 
        public IActionResult Index()
        {
            return Content("Index");
        }

        public async Task<IActionResult> Login()
        {
            var sign = HttpContext.Request.Query["sign"]; 

            if (string.IsNullOrWhiteSpace(sign))
            {
                return Content("Login");
            }
            else
            {
                var claims = new List<Claim> {

                    new Claim(ClaimTypes.Name, sign)

                }; 

                var identity = new ClaimsIdentity(claims,"Identity");

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return Content("Login2");
            } 
        }  


        [Authorize]
        public IActionResult Secret()
        { 
            return Content("Secret");
        }  
    }
}
