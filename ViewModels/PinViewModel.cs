using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TweetTwitch.Models;
using TweetTwitch.Views;

namespace TweetTwitch.ViewModels
{
    class PinViewModel
    {
        private Twitter twitter;

        public PinViewModel(Twitter twitter)
        {
            this.twitter = twitter;
        }

        public ICommand EnterPinCommand
        {
            get;
            private set;
        }
        

        public Twitter Twitter
        {
            get { return twitter; }
            set { twitter = value; }
        }

        public void CloseView()
        {
            Application.Current.MainWindow.Close();
        }


    }
}
