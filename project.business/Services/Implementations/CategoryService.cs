using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.CategoryDto;
using project.business.DTOs.MemberDto;
using project.business.DTOs.PortifolioDto;
using project.business.Exceptions;
using project.business.Services.Interfaces;
using project.core.Entities;
using project.core.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Implementations
{

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync([FromForm] CategoryCreateDto categoryCreateDto)
        {
            Category category = _mapper.Map<Category>(categoryCreateDto);
            category.IsDeleted = false;

            await _categoryRepository.CreateAsync(category);
            await _categoryRepository.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(x => x.Id == id);

            if (category == null) throw new InvalidReferenceException();

            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChanges();
        }

        public async Task<IEnumerable<CategorygetDto>> GetAllAsync()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync(x => x.IsDeleted == false);

            if (categories == null) throw new NullReferenceException("categories couldn't be null!");

            IEnumerable<CategorygetDto> categoryGetDtos = categories.Select(category => new CategorygetDto 
            { Id = category.Id,
              Name = category.Name 
            });

            return categoryGetDtos;
        }

        public async Task<CategorygetDto> GetByIdAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(x => x.Id == id);

            if (category == null) throw new InvalidReferenceException();

            CategorygetDto dto = _mapper.Map<CategorygetDto>(category);

            return dto;
        }

        public async Task ToggleDelete(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(x => x.Id == id);

            if (category == null) throw new InvalidReferenceException();

            category.IsDeleted = !category.IsDeleted;
            category.DeletedDate = DateTime.UtcNow.AddHours(4);

            await _categoryRepository.SaveChanges();
        }

        public async Task UpdateAsync([FromForm] CategoryUpdateDto categoryupdateDto)
        {
            Category category = await _categoryRepository.GetByIdAsync(x => x.Id == categoryupdateDto.Id);

            if (category == null) throw new NullReferenceException("feature couldn't be null!");


            category = _mapper.Map(categoryupdateDto, category);
            await _categoryRepository.SaveChanges();
        }
    }
}
