using System.Collections.Generic;
using System.Configuration;

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

        /// <summary>
        /// Makes 2 requests, we get 10 per min
        /// </summary>
        private void Run()
        {
            RequestService svc = new RequestService(ApiKey);

            string id = svc.GetPlayerIdByName(PlayerNames[1]);

            svc.MakePlayerRequest(id);
        }
    }
}
