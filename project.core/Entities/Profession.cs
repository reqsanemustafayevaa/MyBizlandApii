using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.core.Entities
{
    public class Profession:BaseEntity
    {
        public string Name { get; set; }
       public List<MemberProfession> MemberProfessions { get; set;}
    }
}
