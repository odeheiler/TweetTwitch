using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using LinqToTwitter;
using TweetTwitch.Commands;
using TweetTwitch.Models;
using TweetTwitch.Views;

namespace TweetTwitch.ViewModels
{
     class TwitchInfoViewModel
    {
       
        private Twitch twitch;
        private Twitter twitter;
         private PinView pinView;
        
        

        public TwitchInfoViewModel()
        {
            twitch = new Twitch();
            twitter = new Twitter();
            TweetCommand = new TweetCommand(this);
            GetInfoCommand = new GetInfoCommand(this);
        }

         public ICommand GetInfoCommand
         {
             get; private set; }

         public ICommand TweetCommand
         {
             get;
             private set;
         }

        public Twitch Twitch
        {
            get { return twitch; }
            set { twitch = value; }
        }

        public Twitter Twitter
        {
            get { return twitter; }
            set { twitter = value; }
        }

        public void TweetTwitch()
        {

            /*var pinView = new PinView();
            var childViewModel = new PinViewModel(Twitter);
            pinView.DataContext = childViewModel;
            pinView.ShowDialog();
           */
            string tweet = BuildTweet();
            Tweet(tweet);
            

            
            
            
            
            

        }

        public void GetInfo()
        {
            try
            {


                var twitchInfo = new List<Twitch>();
                string uriEndPoint = "http://api.justin.tv/api/stream/list.xml?channel=" + twitch.Username;
                var xmlDocument = XDocument.Load(uriEndPoint);
                var streams = (from stream in xmlDocument.Descendants("stream")
                               select new Twitch()
                               {
                                   Title = stream.Element("title").Value,
                                   ViewerCount = stream.Element("channel_count").Value,

                                   Username = stream.Element("channel").Element("login").Value,
                                   ChannelUrl = stream.Element("channel").Element("channel_url").Value,
                                   Game = stream.Element("channel").Element("meta_game").Value
                               }).ToList<Twitch>();
                twitch.Game = streams[0].Game;
                twitch.ChannelUrl += streams[0].Username;
                twitch.ViewerCount = streams[0].ViewerCount;
                twitch.Title = streams[0].Title;
            }
            catch (Exception)
            {

                MessageBox.Show("User not currently live");
            }
        }

        public string BuildTweet()
        {
            string tweet = "Come watch: ";
            tweet += twitch.ChannelUrl + twitch.Username + Environment.NewLine + twitch.Title + Environment.NewLine
                + " Current Game: " + twitch.Game + Environment.NewLine + "Current # of Viewers: " + twitch.ViewerCount;
            return tweet;


        }

        public async void Tweet(string tweet)
        {
            /*var auth = new SingleUserAuthorizer
            {

                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                     ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"],
                    OAuthToken = "2377862946-E6gQvONHcAGqDmGAgJJ083E5tRpEw2eqMkABUxk",
                    OAuthTokenSecret = "SbmVmy18TejmkhyaLpEapdj5me58FnfPniS1yKfptEPAd",
                    UserID = 2377862946,
                    ScreenName = "DrunkGaminginc"
                    
                },
                
            };*/

            var auth = new PinAuthorizer()
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"]
                },
                GoToTwitterAuthorization = pageLink => Process.Start(pageLink),
                GetPin = () =>
                {
                    pinView = new PinView();
                    var childViewModel = new PinViewModel(twitter);
                    pinView.DataContext = childViewModel;
                    pinView.ShowDialog();
                    
                    while (pinView.IsActive)
                    {
                        
                    }
                    return twitter.Pin;
                }
            };
            

            await auth.AuthorizeAsync();

            var tw = new TwitterContext(auth);

            await tw.TweetAsync(tweet);

        }





        
    }

   
}
