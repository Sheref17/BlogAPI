using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CustomExceptions.AuthourizedExceptions
{
    public sealed class NotAdminOrEditorException(string message  = "User is not an admin or editor") : ForbiddenException(message)
    {
    }
}
