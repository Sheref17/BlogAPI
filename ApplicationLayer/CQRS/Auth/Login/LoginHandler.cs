using ApplicationLayer.Common;
using ApplicationLayer.CQRS.Auth.AuthDtos;
using ApplicationLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Auth.Login
{
    public class LoginHandler(IIdentityService identityService) : IRequestHandler<LoginCommand, ApiResponse<AuthResponseDto>>
    {


        private readonly IIdentityService _identityService = identityService;

        public async Task<ApiResponse<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.Login(request.Email, request.Password);
        }

    }
}
