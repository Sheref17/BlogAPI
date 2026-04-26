using ApplicationLayer.CQRS.Auth.AuthDtos;
using ApplicationLayer.Interfaces;
using InfrastructureLayer.Identity;
using InfrastructureLayer.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Services
{
    public class IdentityService(UserManager<ApplicationUser> userManager, IJWTService JWTService) : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IJWTService _JWTService = JWTService;

        public async Task<ApiResponse<AuthResponseDto>> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return ApiResponse<AuthResponseDto>.FailResponse(
                    new List<string> { "User not found" }
                );
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

            if (!isPasswordValid)
            {
                return ApiResponse<AuthResponseDto>.FailResponse(
                    new List<string> { "Invalid email or password" }
                );
            }

            var roles = await _userManager.GetRolesAsync(user);

            var token = _JWTService.GenerateToken(user.Id, user.Email, roles);

            return ApiResponse<AuthResponseDto>.SuccessResponse(new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                Roles = roles.ToList()
            });
        }

        public async Task<ApiResponse<AuthResult>> Register(string email, string password, string fullName)
        {
            var user = new ApplicationUser
            {
                Email = email,
                UserName = email,
                FullName = fullName
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded || string.IsNullOrEmpty(fullName))
            {
                if (string.IsNullOrEmpty(fullName))
                {
                    result = IdentityResult.Failed(new IdentityError { Description = "Full name is required" });
                }
                return ApiResponse<AuthResult>.FailResponse(
                    result.Errors.Select(e => e.Description).ToList()
                );
            }

            await _userManager.AddToRoleAsync(user, "Reader");

            return ApiResponse<AuthResult>.SuccessResponse(new AuthResult
            {
                Success = true,
                UserId = user.Id.ToString()
            });
        }
    }
}
