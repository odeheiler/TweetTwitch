using System.Windows;
using TweetTwitch.ViewModels;

namespace TweetTwitch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var viewModel = new TwitchInfoViewModel();
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
