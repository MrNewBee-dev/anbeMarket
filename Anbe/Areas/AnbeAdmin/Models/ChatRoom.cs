using SignalR.Bugeto.Models.Entities;
using System;
using System.Collections.Generic;

namespace Anbe.Areas.AnbeAdmin.Models
{
    public class ChatRoom
    {
        public Guid ID { get; set; }
         public string ConnectionId { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
