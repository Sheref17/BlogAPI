using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CustomExceptions
{
    public sealed class CategroyNotFoundException(string message) : NotFoundException (message)
    {
       
    }

}
