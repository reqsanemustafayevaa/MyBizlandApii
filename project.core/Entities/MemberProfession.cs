using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.core.Entities
{
    public class MemberProfession:BaseEntity
    {
        public int MemberId {  get; set; }
        public Member Member { get; set; }
        public int ProfessionId {  get; set; }
        public Profession Profession { get; set; }
    }
}
