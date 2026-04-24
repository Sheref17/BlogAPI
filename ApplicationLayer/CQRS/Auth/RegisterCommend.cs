using ApplicationLayer.CQRS.Auth.AuthDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Auth
{
    public class RegisterCommend : IRequest<ApiResponse<AuthResult>>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FullName { get; set; } = default!;
    }
}
