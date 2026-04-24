
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
    public interface IJWTService
    {
        string GenerateToken(Guid userId, string email, IList<string> roles);
    }
}
