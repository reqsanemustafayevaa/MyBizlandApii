using Microsoft.AspNetCore.Http;
using project.core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.DTOs.MemberDto
{
    public class MemberUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string RedirectUrl { get; set; }
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
