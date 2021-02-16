using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebChat.Entities.Dtos
{
    public class UserFriendMessageListDto
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public string MessageContent { get; set; }
        public DateTime DeliveredDate { get; set; }
     
    }
}
