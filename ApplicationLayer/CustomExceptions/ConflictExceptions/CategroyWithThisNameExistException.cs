using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CustomExceptions.ConflictExceptions
{
    public class CategroyWithThisNameExistException(string name) : Exception($"Category With This Name : {name} already exist")
    {
    }
}
