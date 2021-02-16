using SimpleWebChat.Core.DataAccess.EntityFramework;
using SimpleWebChat.DataAccess.Abstract;
using SimpleWebChat.DataAccess.Concrete.EntityFramework.Contexts;
using SimpleWebChat.Entities.Concrete;
using SimpleWebChat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWebChat.DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, ChatContext>, IMessageDal
    {
        public List<UserFriendMessageListDto> GetConversation(int userid, int otheruserid)
        {
            using (var _context = new ChatContext())
            {
                var result = new List<UserFriendMessageListDto>();
               
                result = _context.Messages.Where(i => i.MessageFrom == userid && i.MessageTo == otheruserid || i.MessageFrom == otheruserid && i.MessageTo == userid)
                                          .Select(i => new UserFriendMessageListDto()
                                          {
                                              DeliveredDate = i.DeliveredDate,
                                              FriendId = i.MessageTo,
                                              UserId = i.MessageFrom,
                                              MessageContent = i.MessageContent
                                          }).ToList();
                // }
                return result;
            }
        }
    }
}
