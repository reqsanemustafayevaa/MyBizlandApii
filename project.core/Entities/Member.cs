using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.core.Entities
{
    public class Member:BaseEntity  //profession  many to many
    {
        public string Name { get; set; }
        public string RedirectUrl { get; set; }
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public List<MemberProfession> MemberProfessions { get; set;}
    }
}
