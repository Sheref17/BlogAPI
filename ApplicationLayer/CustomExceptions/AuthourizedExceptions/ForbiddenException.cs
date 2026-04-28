using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CustomExceptions.AuthourizedExceptions
{
    public class ForbiddenException(string message) : Exception(message)
    {
    }
}
