using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.MemberDto;
using project.business.DTOs.ProfesiionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface IProfessionService
    {
        Task CreateAsync([FromForm] ProfessionCreateDto professionCreateDto);
        Task UpdateAsync([FromForm] ProfessionUpdateDto professionUpdateDto);

        Task<ProfessionGetDto> GetByIdAsync(int id);
        Task<IEnumerable<MemberGetDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task ToggleDelete(int id);
    }
}
