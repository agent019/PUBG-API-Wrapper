using System;
using System.Collections.Generic;
using System.Configuration;
using TestProject.Models;

namespace TestProject
{
    class Program
    {
        private string ApiKey { get; set; }
        private List<string> PlayerNames { get; set; }
        private List<string> PlayerIds { get; set; }

        public Program()
        {
            ApiKey = ConfigurationManager.AppSettings["apiKey"];
            PlayerNames = new List<string>()
            {
                ConfigurationManager.AppSettings["shawtyPlayerName"],
                ConfigurationManager.AppSettings["liquidPlayerName"]
            };
            PlayerIds = new List<string>()
            {
                ConfigurationManager.AppSettings["shawtyId"],
                ConfigurationManager.AppSettings["liquidId"]
            };
        }

        static void Main(string[] args)
        {
            Program Program = new Program();
            Program.Run();
        }

        private void Run()
        {
            RequestService svc = new RequestService(ApiKey);

            Player player = svc.GetPlayer(PlayerIds[0]);

            Console.WriteLine(player.ToString());

            foreach (string matchId in player.MatchIds)
            {
                Match match = svc.GetMatch(matchId);
                Console.WriteLine(match.ToString());
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
