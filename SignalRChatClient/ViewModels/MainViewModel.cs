namespace SignalRChatClient.WPF.ViewModels
{
    public class MainViewModel
    {
        public ChatViewModel ColorChatViewModel { get; }

        public MainViewModel(ChatViewModel chatViewModel)
        {
            ColorChatViewModel = chatViewModel;
        }
    }
}
