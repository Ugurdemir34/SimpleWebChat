using SimpleWebChat.Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleWebChat.Entities.Concrete
{
    public class Message :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public DateTime DeliveredDate { get; set; }
        public int MessageFrom { get; set; }
        public int MessageTo { get; set; }
    }
}
