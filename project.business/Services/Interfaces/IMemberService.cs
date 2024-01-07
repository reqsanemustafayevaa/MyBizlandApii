using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.MemberDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface IMemberService
    {
        Task CreateAsync([FromForm] MemberCreateDto membercreateDto);
        Task UpdateAsync([FromForm] MemberUpdateDto memberUpdateDto);
        
        Task<MemberGetDto> GetByIdAsync(int id);
        Task<IEnumerable<MemberGetDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task ToggleDelete(int id);
    }
}
