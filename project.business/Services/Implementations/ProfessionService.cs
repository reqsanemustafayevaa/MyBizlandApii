using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.MemberDto;
using project.business.DTOs.ProfesiionDto;
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
    public class ProfessionService : IProfessionService
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;

        public ProfessionService(IProfessionRepository professionRepository
                                 ,IMapper mapper)
        {
            _professionRepository = professionRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync([FromForm] ProfessionCreateDto professionCreateDto)
        {
            Profession profession = _mapper.Map<Profession>(professionCreateDto);
            profession.IsDeleted = false;

            await _professionRepository.CreateAsync(profession);
            await _professionRepository.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            Profession profession = await _professionRepository.GetByIdAsync(x => x.Id == id);

            if (profession == null) throw new InvalidReferenceException();

            _professionRepository.Delete(profession);
            await _professionRepository.SaveChanges();
        }

        public async Task<IEnumerable<MemberGetDto>> GetAllAsync()
        {
            List<Profession> professions = await _professionRepository.GetAllAsync(x=>x.IsDeleted==false);

            if (professions == null) throw new InvalidReferenceException();

            IEnumerable<ProfessionGetDto> professionGetdtos = professions.Select(profession => new ProfessionGetDto
            { Name = profession.Name,
              Id = profession.Id
            });

            return (IEnumerable<MemberGetDto>)professionGetdtos;
        }

       
        public async Task<ProfessionGetDto> GetByIdAsync(int id)
        {
            Profession profession = await _professionRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);

            if (profession == null)
            {
                throw new NullReferenceException();
            }

            ProfessionGetDto ProfessionGetDto = _mapper.Map<ProfessionGetDto>(profession);

            return ProfessionGetDto;
        }

        public async Task ToggleDelete(int id)
        {
            Profession profession = await _professionRepository.GetByIdAsync(profession => profession.Id == id);

            if (profession == null)
            {
                throw new NullReferenceException();
            }

            profession.IsDeleted = !profession.IsDeleted;


            await _professionRepository.SaveChanges();
        }

        public async Task UpdateAsync([FromForm] ProfessionUpdateDto professionUpdateDto)
        {
            Profession profession = await _professionRepository.GetByIdAsync(x => x.Id == professionUpdateDto.Id);

            if (profession == null) throw new NullReferenceException();

            profession = _mapper.Map(professionUpdateDto, profession);

            profession.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _professionRepository.SaveChanges();
        }
    }
}
