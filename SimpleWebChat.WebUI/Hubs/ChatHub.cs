using Microsoft.AspNetCore.SignalR;
using SimpleWebChat.Business.Abstract;
using SimpleWebChat.Entities.Dtos;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebChat.WebUI.Hubs
{
    public class ChatHub:Hub
    {
        private IMessageService _messageService;
        public static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();
        public ChatHub(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public async void SendMessage(string delivereddate,string messagecontent,string messagefrom,string messageto)
        {
            _messageService.Add(new Entities.Concrete.Message
            {
                DeliveredDate = DateTime.Parse(delivereddate),
                MessageContent = messagecontent,
                MessageFrom = Convert.ToInt32(messagefrom),
                MessageTo = Convert.ToInt32(messageto)
            });
            var To = Connections.FirstOrDefault(i => i.Key == messageto).Value;
            if(To!=null)
            {
                await Clients.Client(To).SendAsync("ReceiveMessage", DateTime.Parse(delivereddate).ToShortTimeString(), messagecontent, messagefrom, messageto);          
            }
           
        }
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        public void Connect(string userid)
        {
            Connections.AddOrUpdate(userid, Context.ConnectionId, (a, b) => Context.ConnectionId);
            Console.WriteLine("asadasd");
        }
      
    }
}
