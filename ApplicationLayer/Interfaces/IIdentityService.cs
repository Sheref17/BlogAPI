using ApplicationLayer.CQRS.Auth.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
    public interface IIdentityService
    {
        Task<ApiResponse<AuthResult>> Register(string email, string password, string fullName);
        Task<ApiResponse<AuthResponseDto>> Login(string email, string password);
    }
}
