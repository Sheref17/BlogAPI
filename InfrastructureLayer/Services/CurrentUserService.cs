using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext?
                    .User?
                    .FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                    throw new Exception("User is not authenticated");

                return Guid.Parse(userId);
            }
        }


        public string? Email =>
      _httpContextAccessor.HttpContext?
      .User?
      .FindFirst(ClaimTypes.Email)?.Value;
    }
}
