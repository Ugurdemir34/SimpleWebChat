﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleWebChat.Business.Abstract;
using SimpleWebChat.Entities.Concrete;
using SimpleWebChat.WebUI.Models;

namespace SimpleWebChat.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private IUserService _userService;
        private IMessageService _messageService;

        public HomeController(IUserService userService,IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
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
        public IActionResult NewUser()
        {
            return View();
        }
        public IActionResult Conversation()
        {
          
            return View();
        }
        
        public IActionResult ConversationDetail(int userid,int otheruserid)
        {
            var model = _messageService.GetMessages(userid, otheruserid);
            return View(model);
        }
        [HttpPost]
        public IActionResult NewUser(NewUserModel model)
        {
            var user = new User
            {
                Email = model.Email,
                IsAdmin = model.IsAdmin,
                Name = model.Name,
                Password = model.Password,
                Surname = model.Surname,
                Username = model.Username
            };
            _userService.Add(user);
            ViewData["useraddmessage"] = "New user added successfully";
            return View();
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
