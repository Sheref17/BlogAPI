using ApplicationLayer.Common;
using ApplicationLayer.CQRS.Auth.AuthDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Auth
{
    public class LoginCommand : IRequest<ApiResponse<AuthResponseDto>>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
