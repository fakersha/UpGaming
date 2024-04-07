using MediatR;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Commands.UploadUserScores
{
    public class UploadUserScoresCommand : IRequest
    {
        public List<UserScores> UserScores { get; set; }
    }
}
