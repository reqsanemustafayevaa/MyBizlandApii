using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Exceptions
{
    public class InvalidCredentialsExceptions:Exception
    {
        public InvalidCredentialsExceptions()
        {
            
        }
        public InvalidCredentialsExceptions(string? message):base(message) 
        {
            
        }
    }
}
