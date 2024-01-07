using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Exceptions
{
    public class InvalidImagesizeException:Exception
    {
        public InvalidImagesizeException()
        {
            
        }
        public InvalidImagesizeException(string message):base(message) 
        {
            
        }
    }
}
