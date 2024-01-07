using project.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.DTOs.PortifolioDto
{
    public class PortifolioGetDto
    {
        public int Id {  get; set; }
        public string Description { get; set; }


        public string Category { get; set; }
        public int CategoryId { get; set; }
    }
}
