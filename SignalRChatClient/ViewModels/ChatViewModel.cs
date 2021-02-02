using SignalRChatClient.WPF.Commands;
using SignalRChatClient.WPF.Services;
using SignalRChatModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SignalRChatClient.WPF.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        private byte _red;
        public byte Red
        {
            get
            {
                return _red;
            }
            set
            {
                _red = value;
                OnPropertyChanged(nameof(Red));
            }
        }

        private byte _green;
        public byte Green
        {
            get
            {
                return _green;
            }
            set
            {
                _green = value;
                OnPropertyChanged(nameof(Green));
            }
        }

        private byte _blue;
        public byte Blue
        {
            get
            {
                return _blue;
            }
            set
            {
                _blue = value;
                OnPropertyChanged(nameof(Blue));
            }
        }

        private string _errorMessage = string.Empty;
		public string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				_errorMessage = value;
				OnPropertyChanged(nameof(ErrorMessage));
				OnPropertyChanged(nameof(HasErrorMessage));
			}
		}

		public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

		private bool _isConnected;
		public bool IsConnected
		{
			get
			{
				return _isConnected;
			}
			set
			{
				_isConnected = value;
				OnPropertyChanged(nameof(IsConnected));
			}
		}

		public ObservableCollection<ChatColorViewModel> Messages { get; }

        public ICommand SendColorChatColorMessageCommand { get; }

		public ChatViewModel(SignalRChatService chatService)
		{
            SendColorChatColorMessageCommand = new SendColorChatColorMessageCommand(this, chatService);

			Messages = new ObservableCollection<ChatColorViewModel>();

            chatService.ColorMessageReceived += ChatService_ColorMessageReceived;
		}

        public static ChatViewModel CreatedConnectedViewModel(SignalRChatService chatService)
        {
            ChatViewModel viewModel = new ChatViewModel(chatService);

            chatService.Connect().ContinueWith(task =>
            {
                if(task.Exception != null)
                {
                    viewModel.ErrorMessage = "연결 오류";
                }
            });

            return viewModel;
        }

        private void ChatService_ColorMessageReceived(ChatColor color)
        {
            Messages.Add(new ChatColorViewModel(color));
        }
    }
}
