using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.CategoryDto;
using project.business.DTOs.MemberDto;
using project.business.DTOs.PortifolioDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync([FromForm] CategoryCreateDto categoryCreateDto);
        Task UpdateAsync([FromForm] CategoryUpdateDto categoryUpdateDto);

        Task<CategorygetDto> GetByIdAsync(int id);
        Task<IEnumerable<CategorygetDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task ToggleDelete(int id);
    }
}
