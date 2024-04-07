using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UpGaming.API.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
