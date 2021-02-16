using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SimpleWebChat.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebChat.WebUI.ViewComponents
{
    public class UserListForChatViewComponent:ViewComponent
    {
        private IUserService _userService;
        public UserListForChatViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public ViewViewComponentResult Invoke()
        {
            var users = _userService.GetUserList().OrderBy(a => a.Name).ToList();
            return View(users);
        }
    }
}
