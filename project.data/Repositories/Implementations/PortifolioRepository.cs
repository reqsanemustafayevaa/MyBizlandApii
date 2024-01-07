using project.core.Entities;
using project.core.Repostories.Interfaces;
using project.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.data.Repositories.Implementations
{
    public class PortifolioRepository : GenericRepository<Portifolio>, IPortifolioRepository
    {
        public PortifolioRepository(AppDbContext context) : base(context)
        {
        }
    }
}
