using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleWebChat.Business.Abstract;
using SimpleWebChat.WebUI.Models;

namespace SimpleWebChat.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult UserList()
        {
            var userList = _userService.GetUserList();
            return View(userList);
        }
        public JsonResult DeleteUser(int id)
        {
            var user = _userService.GetById(id);
            _userService.Delete(user);
            return Json(0);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
