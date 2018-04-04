using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using TestProject.Models;
using TestProject.RestWrapper;

namespace TestProject
{
    public class RequestService
    {
        private string ApiKey { get; set; }

        public RequestService() { }
        public RequestService(string key) { this.ApiKey = key; }

        /// <summary>
        /// Given a players username, gets the Id associated for that account.
        /// </summary>
        public string GetPlayerIdByName(string playerName)
        {
            Console.WriteLine("Spinning up rest request...");
            Client client = new Client("https://api.playbattlegrounds.com/");
            string queryEndpoint = "shards/pc-na/players?filter[playerNames]=" + playerName;
            Request request = new Request(queryEndpoint);

            request.AddHeader("Authorization", ApiKey);
            request.AddHeader("Accept", "application/vnd.api+json");

            Console.WriteLine("Firing off rest request...");
            Response response = client.Execute(request);
            Console.WriteLine();

            Console.WriteLine("Status code: " + (int)response.StatusCode + " : " + response.StatusDescription);
            Console.WriteLine("Content type: " + response.ContentType);

            JObject obj = JObject.Parse(response.Content);
            return (string)obj["data"][0]["id"];
        }

        /// <summary>
        /// Makes a request to the pubg API for information about a player, by player id.
        /// </summary>
        public void MakePlayerRequest(string id)
        {
            Console.WriteLine("Spinning up rest request...");
			Client client = new Client("https://api.playbattlegrounds.com/");

            string queryEndpoint = "shards/pc-na/players/" + id;
            Request request = new Request(queryEndpoint);
			
			request.AddHeader("Authorization", ApiKey);
			request.AddHeader("Accept", "application/vnd.api+json");

            Console.WriteLine("Firing off rest request...");
            Response response = client.Execute(request);
            Console.WriteLine();

            Console.WriteLine("Status code: " + (int)response.StatusCode + " : " + response.StatusDescription);
            Console.WriteLine("Content type: " + response.ContentType);

            Console.WriteLine();
            Console.Write("Body: ");
            File.WriteAllText("../../../Data/playerdata.json", response.Content);
            Console.WriteLine("written");

            Player player = BuildPlayerFromResponse(response.Content);
            Console.WriteLine(player.ToString());
            Console.ReadLine();
        }

        public Player BuildPlayerFromResponse(string jsonPlayer)
        {
            PlayerDTO dto = JsonConvert.DeserializeObject<PlayerDTO>(jsonPlayer);
            Player player = new Player()
            {
                Id = dto.Data.Id,
                Created = DateTime.Parse(dto.Data.Attributes.Created),
                Name = dto.Data.Attributes.Name,
                Version = dto.Data.Attributes.Version,
                Shard = dto.Data.Attributes.Shard,
                Title = dto.Data.Attributes.Title,
                Updated = DateTime.Parse(dto.Data.Attributes.Updated),
                MatchIds = dto.Data.Relationships.Matches.Data.Select(x => x.Id).ToList()
            };

            return player;
        }
    }
}
