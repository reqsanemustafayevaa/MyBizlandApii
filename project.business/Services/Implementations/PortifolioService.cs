using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.MemberDto;
using project.business.DTOs.PortifolioDto;
using project.business.Exceptions;
using project.business.Services.Interfaces;
using project.core.Entities;
using project.core.Repostories.Interfaces;
using project.data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Implementations
{
    public class PortifolioService : IPortifolioService
    {
        private readonly IPortifolioRepository _portifolioRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public PortifolioService(IPortifolioRepository portifolioRepository,
                                 ICategoryRepository categoryRepository,
                                 IMapper mapper)
        {
            _portifolioRepository = portifolioRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync([FromForm] PortifolioCreateDto portifolioCreateDto)
        {
            if (!_categoryRepository.Table.Any(x => x.Id == portifolioCreateDto.CategotyId))
            {
                throw new InvalidReferenceException();
            }
            Portifolio portifolio = _mapper.Map<Portifolio>(portifolioCreateDto);
            await _portifolioRepository.CreateAsync(portifolio);
            await _portifolioRepository.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            Portifolio portifolio = await _portifolioRepository.GetByIdAsync(x => x.Id == id);

            if (portifolio == null) throw new InvalidReferenceException();
            _portifolioRepository.Delete(portifolio);
            await _portifolioRepository.SaveChanges();
        }

        public async Task<IEnumerable<PortifolioGetDto>> GetAllAsync()
        {
            IEnumerable<Portifolio> portifolios = await _portifolioRepository.GetAllAsync(x => x.IsDeleted == false, "Category");

            IEnumerable<PortifolioGetDto> portifolioGetDtos = portifolios.Select(portfolio => new PortifolioGetDto
            {
                Id = portfolio.Id,
                
                Description = portfolio.Description,
                Category = portfolio.Category.Name,
               
                
            });

            return portifolioGetDtos;
        }

        
        public async Task<PortifolioGetDto> GetByIdAsync(int id)
        {
            Portifolio portifolio = await _portifolioRepository.GetByIdAsync(x => x.Id == id, "Category");

            if (portifolio == null) throw new InvalidReferenceException();

            PortifolioGetDto portifolioGetDto = _mapper.Map<PortifolioGetDto>(portifolio);
            portifolioGetDto.Category = portifolio.Category.Name;
           

            return portifolioGetDto;
        }

        public async Task ToggleDelete(int id)
        {
            Portifolio portifolio = await _portifolioRepository.GetByIdAsync(x => x.Id == id, "Category");

            if (portifolio == null) throw new InvalidReferenceException();

            portifolio.IsDeleted = !portifolio.IsDeleted;
            portifolio.DeletedDate = DateTime.UtcNow.AddHours(4);

            await _portifolioRepository.SaveChanges();
        }

        public async Task UpdateAsync([FromForm] PortifolioUpdateDto portifolioUpdateDto)
        {
            Portifolio portifolio = await _portifolioRepository.GetByIdAsync(x => x.Id == portifolioUpdateDto.Id);

            if (portifolio == null) throw new InvalidReferenceException();

            if (!_categoryRepository.Table.Any(category => category.Id == portifolioUpdateDto.CategoryId))
            {
                throw new InvalidReferenceException();
            }

            portifolio = _mapper.Map(portifolioUpdateDto, portifolio);

            await _portifolioRepository.SaveChanges();
        }

        
    }
}
