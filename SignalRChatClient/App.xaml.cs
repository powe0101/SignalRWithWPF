using SignalRChatClient.WPF.Services;
using SignalRChatClient.WPF.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows;

namespace SignalRChatClient.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/colorchat")
                .Build();

            ChatViewModel chatViewModel = ChatViewModel.CreatedConnectedViewModel(new SignalRChatService(connection));

            MainWindow window = new MainWindow
            {
                DataContext = new MainViewModel(chatViewModel)
            };

            window.Show();
        }
    }
}
