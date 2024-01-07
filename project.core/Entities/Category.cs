using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.core.Entities
{
    public class Category:BaseEntity  //portifolio one-to-many
    {
        public string Name {  get; set; }
        public List<Portifolio> Portifolios { get; set; }
    }
}
