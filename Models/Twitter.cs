using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;

namespace TweetTwitch.Models
{
    class Twitter
    {
        private string login;
        private string password;
        private string pin;

        public Twitter()
        {
            Login = "";
            Password = "";
        }

        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

       

        



        
    }
}
