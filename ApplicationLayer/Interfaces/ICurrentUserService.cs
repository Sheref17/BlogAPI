using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        string? Email { get; }
        bool IsInRole(string role);
     
    }
}
