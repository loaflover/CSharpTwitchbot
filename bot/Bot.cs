using System;
using TwitchLib.Api.V5;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;
using System.Windows.Forms;

namespace BotApp
{
    internal class Bot
    {
        ConnectionCredentials creds;
        TwitchClient client;

        string channel;
        string Oauth;
        public void bot()
        {
            channel = Console.ReadLine();
            Oauth = Console.ReadLine();
            creds = new ConnectionCredentials(channel, Oauth);



        }
        public void Connect(bool isLogging)
        {
            client = new TwitchClient();
            Console.WriteLine("Loaflover_");
            client.Initialize(creds, channel);
            client.OnConnected += Client_OnConnected;

            Console.WriteLine("[Bot]: Connecting...");

            if (isLogging)
                client.OnLog += Client_OnLog;

            client.OnError += Client_OnError;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnChatCommandReceived += Client_OnChatCommandReceived;
            client.AddChatCommandIdentifier('$');

            client.Connect();

        }

        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            switch (e.Command.CommandText.ToLower())
            {
                case "roll":
                    string msg = $"{e.Command.ChatMessage.DisplayName} Rolled {RndInt(1, 6)}";
                    client.SendMessage(channel, msg);
                    Console.WriteLine($"[Bot]: {msg}");
                    break;
                case "social":
                    client.SendMessage(channel, "Here are all my social links! YouTube: http://bit.ly/3p01GJD Twitter: https://bit.ly/369XH5f Discord: http://bit.ly/36h7zMm.");
                    break;
                case "help":
                    client.SendMessage(channel, "There is a panel with all commands and a link to the github repo below, please check it out!");
                    break;
                case "hello":
                    client.SendMessage(channel, "hi " + e.Command.ChatMessage.DisplayName + ", how are you?");
                    break;
                case "sus":
                    if (e.Command.ChatMessage.DisplayName == "LoafLover_")
                    {
                        client.SendMessage(channel, e.Command.ChatMessage.DisplayName + ", you sussy enough. yay!");
                        break;
                    }
                    client.SendMessage(channel, e.Command.ChatMessage.DisplayName + ", you are not sussy enough. go to horny jail immediatly.");
                    break;

            }

            if (e.Command.ChatMessage.DisplayName == "LoafLover_")
            {
                switch (e.Command.CommandText.ToLower())
                {
                    case "hi":
                        client.SendMessage(channel, "ayo whats up loaf");
                        break;
                }
            }
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            //if you want to, this is to remove banned words. make sure to ADD A NEW VARIABLE OF TYPE ARREY CALLED _bannedwords AND TO ADD YOUR BANNED WORDS
            //for (int i = 0; i < _bannedWords.Length; i++)
            //{
            //    if (e.ChatMessage.Message.ToLower().Contains(_bannedWords[i]))
            //    {
            //        client.BanUser(channel, e.ChatMessage.Username);
            //    }
            //}
            Console.WriteLine($"[{e.ChatMessage.DisplayName}]: {e.ChatMessage.Message}");

        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine(e.Data);

        }

        private void Client_OnError(object sender, OnErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine("[Bot]: Connected");
        }

        internal void Disconnect()
        {
            Console.WriteLine("[Bot]: Disonnecting and closing application");

            client.Disconnect();
        }

        private int RndInt(int min, int max)
        {
            int value;

            Random rnd = new Random();

            value = rnd.Next(min, max + 1);

            return value;
        }
        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
    }

}
       

        


        

