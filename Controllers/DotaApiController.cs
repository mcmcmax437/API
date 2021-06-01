using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Clients;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;
using API.Extensions;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DotaApiController : ControllerBase
    {

        private readonly ILogger<DotaApiController> _logger;
        private readonly DotaClient _dotaClient;
        private readonly IDynamoDbClient _dynamoDBClient;

        public DotaApiController(ILogger<DotaApiController> logger, DotaClient dotaClient, IDynamoDbClient dynamoDBClient)
        {
            _logger = logger;
            _dotaClient = dotaClient;
            _dynamoDBClient = dynamoDBClient;

        }

        [HttpGet("accountById")]
        public async Task<AccountByID> GetAccountById([FromQuery] IdParametersForSearch parameters)
        {
            var dotaid = await _dotaClient.GetAccountById(parameters.id);
            return dotaid;
        }

        [HttpGet("Win_Lose")]
        public async Task<Win_LoseResponce> GetWin_Lose([FromQuery] IdParametersForSearch parameters)
        {
            // var dotaid = await _dotaClient.GetAccountById(parameters.id);

            var WinLose = await _dotaClient.GetWinLose(parameters.id);
            double c;
            c = (WinLose.Win * 100) / (WinLose.Win + WinLose.Lose);
            c = Math.Round(c, 2);
            var result = new Win_LoseResponce
            {
                Win = WinLose.Win,
                Lose = WinLose.Lose,
                AllMatch = (WinLose.Lose + WinLose.Win),

                WinRate = c
            };
            return result;
        }

        [HttpGet("find_match")]
        public async Task<MatchByID> GetMatchbyID([FromQuery] IdforMatch parameters)
        {
            var matchid = await _dotaClient.GetMatchbyID(parameters.matchid);

            return matchid;
        }

        [HttpGet("turnir")]
        public async Task<List<Turnir>> Turnir([FromQuery] TurnirPage parameters)
        {
            var turnirRESP = await _dotaClient.Turnir(parameters.page);

            return turnirRESP;
        }
        [HttpGet("team")]
        public async Task<List<TeamById>> GetTeam([FromQuery] TeamId parameters)
        {
            var team = await _dotaClient.GetTeam();

            return team;
        }


        [HttpGet("heroByid")]
        public async Task<List<HeroRoot>> GetHero([FromQuery] TeamId parameters)
        {
            var HeroList = await _dotaClient.GetHero(parameters.id);

            return HeroList;
        }





        [HttpGet("getINFOfromDB")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFavouriteHeroByPrivateID([FromQuery] string privateID)
        {
            var result = await _dynamoDBClient.GetDataFromDB(privateID);
            if (result == null)
            {
                return NotFound("Record does not exist in database");
            }
            var antwort = new DBresponce
            {
                id = result.id,
                Hero = result.Hero
               // Hero = result.Hero,
                //ID = result.ID,
                //UserID = result.UserID,
               // Number = result.Number
            };

            return Ok(antwort);
        }


        [HttpPost("add")]
        public async Task<IActionResult> PostDatatoDynamo([FromBody] HeroForPost heroForPost)
        {
            var data = new HeroDBRepository
            {
               id = Convert.ToString(heroForPost.id),
               Hero = heroForPost.localized_name

            };
             await _dynamoDBClient.PostDataToDb(data);
            return Ok();
        }
        


    }
}
