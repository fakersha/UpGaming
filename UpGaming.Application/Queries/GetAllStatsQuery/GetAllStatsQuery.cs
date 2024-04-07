using MediatR;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetAllStatsQuery
{
    public class GetAllStatsQuery : IRequest<StatsResult>
    {
    }
}
