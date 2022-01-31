using System;
using TwitchLib.Api.V5;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BotApp
{
    public class Bot
    {
        
        ConnectionCredentials creds;
        TwitchClient client;
        string channel;
        string Oauth;
        public Bot()
        {

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();
            AllocConsole();
            Console.WriteLine("insert channel name:");
            this.channel = Console.ReadLine();
            Console.WriteLine("insert Oauth key:");
            this.Oauth = Console.ReadLine();
            this.creds = new ConnectionCredentials(channel, Oauth);



        }
        public void Connect(bool isLogging)
        {
            this.client = new TwitchClient();
            Console.WriteLine("Loaflover_");
            this.client.Initialize(this.creds, this.channel);
            this.client.OnConnected += Client_OnConnected;

            Console.WriteLine("[Bot]: Connecting...");

            if (isLogging)
                this.client.OnLog += Client_OnLog;

            this.client.OnError += Client_OnError;
            this.client.OnMessageReceived += Client_OnMessageReceived;
            this.client.OnChatCommandReceived += Client_OnChatCommandReceived;
            this.client.AddChatCommandIdentifier('$');

            this.client.Connect();

        }
        public void send_message(string message)
        {
            this.client.SendMessage(channel, message);
        }
        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            switch (e.Command.CommandText.ToLower())
            {
                case "roll":
                    string msg = $"{e.Command.ChatMessage.DisplayName} Rolled {RndInt(1, 6)}";
                    this.client.SendMessage(channel, msg);
                    Console.WriteLine($"[Bot]: {msg}");
                    break;
                case "social":
                    this.client.SendMessage(channel, "Here are all my social links! YouTube: http://bit.ly/3p01GJD Twitter: https://bit.ly/369XH5f Discord: http://bit.ly/36h7zMm.");
                    break;
                case "help":
                    this.client.SendMessage(channel, "There is a panel with all commands and a link to the github repo below, please check it out!");
                    break;
                case "hello":
                    this.client.SendMessage(channel, "hi " + e.Command.ChatMessage.DisplayName + ", how are you?");
                    break;
                case "sus":
                    if (e.Command.ChatMessage.DisplayName == "LoafLover_")
                    {
                        this.client.SendMessage(channel, e.Command.ChatMessage.DisplayName + ", you sussy enough. yay!");
                        break;
                    }
                    this.client.SendMessage(channel, e.Command.ChatMessage.DisplayName + ", you are not sussy enough. go to horny jail immediatly.");
                    break;

            }

            if (e.Command.ChatMessage.DisplayName == "LoafLover_")
            {
                switch (e.Command.CommandText.ToLower())
                {
                    case "hi":
                        this.client.SendMessage(channel, "ayo whats up loaf");
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

            this.client.Disconnect();
        }

        private int RndInt(int min, int max)
        {
            int value;

            Random rnd = new Random();

            value = rnd.Next(min, max + 1);

            return value;
        }
  
    }

}
       

        


        

