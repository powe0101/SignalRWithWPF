using Microsoft.AspNetCore.SignalR.Client;
using SignalRChatModel;
using System;
using System.Threading.Tasks;

namespace SignalRChatClient.WPF.Services
{
    public class SignalRChatService
    {
        private readonly HubConnection _connection;

        public event Action<ChatColor> ColorMessageReceived;

        public SignalRChatService(HubConnection connection)
        {
            _connection = connection;

            _connection.On<ChatColor>("ReceiveColorMessage", (color) => ColorMessageReceived?.Invoke(color));
        }

        public async Task Connect()
        {
            await _connection.StartAsync();
        }

        public async Task SendColorMessage(ChatColor color)
        {
            await _connection.SendAsync("SendColorMessage", color);
        }
    }
}
