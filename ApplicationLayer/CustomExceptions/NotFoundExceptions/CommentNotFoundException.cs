using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CustomExceptions.NotFoundExceptions
{
    public class CommentNotFoundException(int id) : NotFoundException($"Comment With This Id {id} is not Found")
    {
    }
}
