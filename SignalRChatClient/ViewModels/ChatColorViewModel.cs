using SignalRChatModel;
using System;
using System.Windows.Media;

namespace SignalRChatClient.WPF.ViewModels
{
    public class ChatColorViewModel : ViewModelBase
    { 
        public ChatColor ColorChatColor { get; set; }

        public Brush ColorBrush
        {
            get
            {
                try
                {
                    return new SolidColorBrush(Color.FromRgb(
                        ColorChatColor.Red,
                        ColorChatColor.Green,
                        ColorChatColor.Blue));
                }
                catch (FormatException)
                {
                    return new SolidColorBrush(Colors.Black);
                }
            }
        }

        public ChatColorViewModel(ChatColor colorChatColor)
        {
            ColorChatColor = colorChatColor;
        }
    }
}
