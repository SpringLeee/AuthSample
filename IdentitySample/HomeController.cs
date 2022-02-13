using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySample
{
    [Route("[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return Content("Secret");
        } 

        public async Task<IActionResult> Register(string username,string password)
        {
            var user = new IdentityUser { 
            
                UserName = username,
                Email = "xi.shuai@outlook.com"  

            };

            var result = await _userManager.CreateAsync(user,password);

            if (result.Succeeded)
            {
                return Content("注册成功!");
            }
            else
            {
                return Content("注册失败!"); 
            }
        }

    }
}
