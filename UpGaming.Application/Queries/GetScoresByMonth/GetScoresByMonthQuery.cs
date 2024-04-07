using MediatR;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetScoresByMonth
{
    public class GetScoresByMonthQuery : IRequest<List<ScoreData>>
    {
        public DateTime Month { get; set; }
    }
}
