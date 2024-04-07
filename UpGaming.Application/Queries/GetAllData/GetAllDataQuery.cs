using MediatR;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Queries.GetAllData
{
    public class GetAllDataQuery : IRequest<List<UserScoresDto>>
    {

    }
}
