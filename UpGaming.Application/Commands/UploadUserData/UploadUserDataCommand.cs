using MediatR;
using UpGaming.Domain.Entities;

namespace UpGaming.Application.Commands.UploadUserData
{
    public class UploadUserDataCommand : IRequest
    {
        public List<UserData> Users { get; set; }
    }
}
