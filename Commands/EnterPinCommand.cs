using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TweetTwitch.ViewModels;

namespace TweetTwitch.Commands
{
    class EnterPinCommand : ICommand
    {
        public EnterPinCommand(PinViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private PinViewModel viewModel;



        public bool CanExecute(object parameter)
        {
            return !String.IsNullOrWhiteSpace(viewModel.Twitter.Pin);
        }

        public void Execute(object parameter)
        {
            
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
