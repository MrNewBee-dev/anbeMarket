using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Anbe.Hubs
{
    public class SiteChatHub : Hub
    {
        public async Task SendNewMessage(string Sender, string Message) {
        
        await Clients.All.SendAsync("GetNameMessage",Sender, Message);
        
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
