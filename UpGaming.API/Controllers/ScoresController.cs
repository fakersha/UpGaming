using Microsoft.AspNetCore.Mvc;
using UpGaming.Application.Commands.UploadUserData;
using UpGaming.Application.Commands.UploadUserScores;
using UpGaming.Application.Queries.GetAllData;
using UpGaming.Application.Queries.GetAllStatsQuery;
using UpGaming.Application.Queries.GetScoresByDay;
using UpGaming.Application.Queries.GetScoresByMonth;
using UpGaming.Domain.Entities;

namespace UpGaming.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoresController : ApiControllerBase
    {

        [HttpGet("get-scores-by-day")]
        public async Task<List<ScoreData>> GetScoresByDay([FromQuery]GetScoresByDayQuery request) => await Mediator.Send(request);

        [HttpGet("get-scores-by-month")]
        public async Task<List<ScoreData>> GetScoresByMonth([FromQuery] GetScoresByMonthQuery request) => await Mediator.Send(request);

        [HttpGet("get-all-data")]
        public async Task<List<UserScoresDto>> GetAllData([FromQuery] GetAllDataQuery request) => await Mediator.Send(request);

        [HttpGet("get-stats")]
        public async Task<StatsResult> GetStatsResults([FromQuery] GetAllStatsQuery request) => await Mediator.Send(request);

        [HttpPost("upload-user-scores")]
        public async Task UploadUserScores(UploadUserScoresCommand request) => await Mediator.Send(request);
    }

}
