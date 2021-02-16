using SimpleWebChat.Core.DataAccess;
using SimpleWebChat.Entities.Concrete;
using SimpleWebChat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebChat.DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<UserFriendMessageListDto> GetConversation(int userid, int otheruserid);
    }
}
