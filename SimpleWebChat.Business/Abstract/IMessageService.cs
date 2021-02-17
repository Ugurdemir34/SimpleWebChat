using SimpleWebChat.Entities.Concrete;
using SimpleWebChat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebChat.Business.Abstract
{
    public interface IMessageService
    {
        List<UserFriendMessageListDto> GetMessages(int userid,int otheruserid);
        void Add(Message newMessage);
    }
}
