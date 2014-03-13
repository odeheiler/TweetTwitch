using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace TweetTwitch.Models
{
    class Twitch :INotifyPropertyChanged
    {
        private string title;
        private string channelUrl;
        private string viewerCount;
        private string username;
        private string game;

        public Twitch()
        {
            Title = "";
            ChannelUrl = "twitch.tv/";
            ViewerCount = "";
            Username = "";
            Game = "";
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                this.OnPropertyChanged("Title");
            }
        }

        public string ChannelUrl
        {
            get { return channelUrl; }
            set
            {
                channelUrl = value;
                this.OnPropertyChanged("ChannelUrl");
            }
        }

        public string ViewerCount
        {
            get { return viewerCount; }
            set
            {
                viewerCount = value;
                this.OnPropertyChanged("ViewerCount");
            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                this.OnPropertyChanged("Username");
            }
        }

        public string Game
        {
            get { return game; }
            set
            {
                game = value;
                this.OnPropertyChanged("Game");
            }
        }

       

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
