using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CustomExceptions.NotFoundExceptions
{
    public class TagNotFoundException(int id) :NotFoundException($"Tag with ID {id} not found.")
    {
    }
}
