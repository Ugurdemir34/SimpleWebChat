using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SimpleWebChat.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebChat.WebUI.ViewComponents
{
    public class ConversationViewComponent:ViewComponent
    {
        private IMessageService _messageService;
        public ConversationViewComponent(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public ViewViewComponentResult Invoke(int userid,int otheruserid)
        {
            var usermessage = _messageService.GetMessages(userid, otheruserid);
            return View(usermessage);
        }
    }
}
