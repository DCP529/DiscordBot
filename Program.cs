using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            

            DiscordClient client;
            client = new DiscordClient(new DiscordConfiguration()
            {
                Token =
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            });

            client.MessageCreated += Client_MessageCreated;

            client.ConnectAsync();

            Console.ReadLine();
        }

        private async static Task Client_MessageCreated(DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            var aut = e.Author.Username;
            var msg = e.Message.Content;

            Console.WriteLine($"{aut} {msg}");

            if (msg.StartsWith("&"))
            {
                string res = string.Empty;
                
                switch (msg)
                {
                    case "&time": res = DateTime.Now.ToLongTimeString(); break;
                    case "&Богорош": res = "Лох!"; break;
                }


                await e.Message.RespondAsync(res);
            }
            
        }
    }
}
