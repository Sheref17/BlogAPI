using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CustomExceptions.NotFoundExceptions
{
    public sealed class CategroyNotFoundException(int id) : NotFoundException($"Category With This Id : {id} not found")
    {

    }

}
