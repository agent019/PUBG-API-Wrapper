using PUBGAPIWrapper;
using PUBGAPIWrapper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using TestProject.GUI;

namespace TestProject
{
    class Program
    {
        private string ApiKey { get; set; }
        private string PlayerName { get; set; }
        private string PlayerId { get; set; }
        private Shard DefaultShard { get; set; }

        public Program()
        {
            ApiKey = ConfigurationManager.AppSettings["apiKey"];
            PlayerName = ConfigurationManager.AppSettings["playerName"];
            PlayerId = ConfigurationManager.AppSettings["playerId"];
            DefaultShard = Shard.PC_NA;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Program Program = new Program();
            Program.Run();
        }

        private void Run()
        {
            RequestService svc = new RequestService(ApiKey);

            Player player = svc.GetPlayer(DefaultShard, PlayerId);

            Console.WriteLine(player.ToString());

            string matchId = player.MatchIds[0];

            Match match = svc.GetMatch(DefaultShard, matchId);

            Telemetry telemetry = svc.GetTelemetry(match.Telemetry.URL);

            List<LogPlayerPosition> myLocations = telemetry.PlayerPositionEvents.Where(ppe => ppe.Character.AccountId == player.Id).OrderBy(ppe => ppe.ElapsedTime).ToList();
            Application.Run(new Form1(myLocations));

            Console.ReadLine();
        }
    }
}
