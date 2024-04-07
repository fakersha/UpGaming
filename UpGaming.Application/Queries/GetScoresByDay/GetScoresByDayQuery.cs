using MediatR;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetScoresByDay
{
    public class GetScoresByDayQuery : IRequest<List<ScoreData>>
    {
        public DateTime Day { get; set; }
    }
}
