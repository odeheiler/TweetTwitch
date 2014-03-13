using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TweetTwitch.ViewModels;

namespace TweetTwitch.Commands
{
    class GetInfoCommand : ICommand
    {
        public GetInfoCommand(TwitchInfoViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private TwitchInfoViewModel viewModel;



        public bool CanExecute(object parameter)
        {
            return !String.IsNullOrWhiteSpace(viewModel.Twitch.Username);
        }

        public void Execute(object parameter)
        {
            viewModel.GetInfo();
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
