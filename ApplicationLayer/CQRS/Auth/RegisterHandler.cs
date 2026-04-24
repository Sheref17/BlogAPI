using ApplicationLayer.CQRS.Auth.AuthDtos;
using ApplicationLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Auth
{
    public class RegisterHandler(IIdentityService identityService) : IRequestHandler<RegisterCommend, ApiResponse<AuthResult>>
    {

        private readonly IIdentityService _identityService = identityService;

        public async Task<ApiResponse<AuthResult>> Handle(RegisterCommend request, CancellationToken cancellationToken)
        {
            return await _identityService.Register(request.Email, request.Password, request.FullName);
        }
    }
}
