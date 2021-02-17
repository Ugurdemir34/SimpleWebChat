using SimpleWebChat.Business.Abstract;
using SimpleWebChat.DataAccess.Abstract;
using SimpleWebChat.Entities.Concrete;
using SimpleWebChat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebChat.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message newMessage)
        {
            _messageDal.Add(newMessage);
        }

        public List<UserFriendMessageListDto> GetMessages(int userid, int otheruserid)
        {
           return _messageDal.GetConversation(userid, otheruserid);
        }
    }
}
