using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Exceptions
{
    public class InvalidRegisterException:Exception
    {
        public InvalidRegisterException()
        {
            
        }
        public InvalidRegisterException(string message):base(message) 
        {
            
        }
    }
}
