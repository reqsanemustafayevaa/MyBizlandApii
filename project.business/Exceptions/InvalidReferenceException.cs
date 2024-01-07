using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Exceptions
{
    public class InvalidReferenceException:Exception
    {
        public InvalidReferenceException()
        {
            
        }
        public InvalidReferenceException(string message):base(message) 
        {
            
        }
    }
}
