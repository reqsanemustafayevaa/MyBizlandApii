using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.core.Entities
{
    public class Portifolio:BaseEntity
    {
        public string Description {  get; set; }
        public bool All { get; set; }
        public bool App { get; set; }
        public bool Card { get; set; }
        public bool Web { get; set; }
       
        public Category Category { get; set; }
        public int CategoryId { get; set; } 

    }
}
