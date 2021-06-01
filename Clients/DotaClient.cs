
using API.Model;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace API.Clients
{
    public class DotaClient
    {
        private readonly HttpClient _client;
        private static string _address;
        private static string _address2;
        public static string _apikey;
        public static string _apikey2;





        public DotaClient()
        {
            _address = Constants.adress;
            _address2 = Constants.adress2;
            _apikey = Constants.apiKey;
            _apikey2 = Constants.apiKeyPanda;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_address);
           
        }
        public async Task<AccountByID> GetAccountById(int accountid)
        {
            var responce = await _client.GetAsync($"/api/players/{accountid}?api_key={_apikey}");
            responce.EnsureSuccessStatusCode();

            var content = responce.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<AccountByID>(content);

            return result;
            //convert to json



        }

        public async Task<Win_Lose> GetWinLose(int accountid)
        {
            var responce = await _client.GetAsync($"/api/players/{accountid}/wl?api_key={_apikey}");
            responce.EnsureSuccessStatusCode();

            var content2 = responce.Content.ReadAsStringAsync().Result;

            var result2 = JsonConvert.DeserializeObject<Win_Lose>(content2);

            return result2;
            //convert to json



        }

        public async Task<MatchByID> GetMatchbyID(long matchid)
        {
            var responce3 = await _client.GetAsync($"api/matches/{matchid}?api_key={_apikey}");
     
            responce3.EnsureSuccessStatusCode();

            var content3 = responce3.Content.ReadAsStringAsync().Result;

            var result3 = JsonConvert.DeserializeObject<MatchByID>(content3);

            return result3;
            //convert to json



        }

        public async Task<List<Turnir>> Turnir(long pageid)
        {
            var responce4 = await _client.GetAsync($"https://api.pandascore.co/dota2/tournaments?page={pageid}&token=TY-0ZWiC6gInmPPvV35RzeFPg2aUQPIQNUamdpV460-oN9OJ03w");

            responce4.EnsureSuccessStatusCode();

           var content4 = responce4.Content.ReadAsStringAsync().Result;

            var result4 = JsonConvert.DeserializeObject<List<Turnir>>(content4);

            return result4;
           
        }

        public async Task<List<TeamById>> GetTeam()
        {
      
            var responce5 = await _client.GetAsync($"api/teams?api_key={_apikey}");

            responce5.EnsureSuccessStatusCode();

            var content5 = responce5.Content.ReadAsStringAsync().Result;

            var result5 = JsonConvert.DeserializeObject<List<TeamById>>(content5);

            return result5;
            



        }

        public async Task<List<HeroRoot>> GetHero(int heroid)
        {
        
            var responce6 = await _client.GetAsync($"api/heroes?api_key={_apikey}");

            responce6.EnsureSuccessStatusCode();

            var content6 = responce6.Content.ReadAsStringAsync().Result;

            var result6 = JsonConvert.DeserializeObject<List<HeroRoot>>(content6);
            foreach (var element in result6)
            {
                if(element.id == heroid)
                {
                     var hero = new HeroForPost
                    {
                        id = element.id,
                        localized_name = element.localized_name
                       // primary_attr = element.primary_attr
                    };
                    
                }
                
            }

            return result6;



        }
    }
}
