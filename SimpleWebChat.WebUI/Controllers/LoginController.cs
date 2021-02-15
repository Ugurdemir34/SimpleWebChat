using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebChat.Business.Abstract;
using SimpleWebChat.DataAccess.Abstract;
using SimpleWebChat.Entities.Dtos;

namespace SimpleWebChat.WebUI.Controllers
{
    
    public class LoginController : Controller
    {
        private IUserService _userService;
        private IHttpContextAccessor _httpContextAccessor;
        public LoginController(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserForLoginDto model)
        {
            var result = _userService.Login(model);
            if(result!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim("Name",model.Username)
                };
                var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                _httpContextAccessor.HttpContext.Session.SetString("username", result.Username);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                ViewData["mesaj"] = "";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["mesaj"] = "Kullanıcı Adı veya Parola Hatalı !";
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}
