using Microsoft.AspNetCore.SignalR;
using SignalRChatModel;
using System.Threading.Tasks;

namespace SignalRChatServer.SignalR.Hubs
{
    public class ColorChatHub : Hub
    {
        public async Task SendColorMessage(ChatColor color)
        {
            await Clients.All.SendAsync("ReceiveColorMessage", color);
        }
    }
}
