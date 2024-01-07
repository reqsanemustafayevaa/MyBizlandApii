using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.MemberDto;
using project.business.DTOs.PortifolioDto;
using project.business.DTOs.ProfesiionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface IPortifolioService
    {
        Task CreateAsync([FromForm] PortifolioCreateDto portifolioCreateDto);
        Task UpdateAsync([FromForm] PortifolioUpdateDto portifolioUpdateDto);

        Task<PortifolioGetDto> GetByIdAsync(int id);
        Task<IEnumerable<PortifolioGetDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task ToggleDelete(int id);
    }
}
