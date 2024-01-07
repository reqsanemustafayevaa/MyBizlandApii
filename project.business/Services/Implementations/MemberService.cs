using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.MemberDto;
using project.business.Exceptions;
using project.business.Extentions;
using project.business.Services.Interfaces;
using project.core.Entities;
using project.core.Repostories.Interfaces;

namespace project.business.Services.Implementations
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public MemberService(IMemberRepository memberRepository
                             , IMapper mapper
                             , IWebHostEnvironment env)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
            _env = env;
        }
        public async Task CreateAsync([FromForm] MemberCreateDto membercreateDto)
        {
            if (membercreateDto.ImageFile != null)
            {
                if (membercreateDto.ImageFile.ContentType != "image/png" && membercreateDto.ImageFile.ContentType != "image/jpeg")
                {
                    throw new InvalidContentTypeException("file must be .jpg or png");
                }

                if (membercreateDto.ImageFile.Length > 1048576)
                {
                    throw new InvalidImagesizeException("file must be lower than 1mb!");
                }
            }
            else
            {
                throw new InvalidReferenceException("required!");
            }



            string ImgUrl = Helper.SaveFile(_env.WebRootPath, "uploads/Members", membercreateDto.ImageFile);

            Member member = _mapper.Map<Member>(membercreateDto);
            member.ImageUrl=ImgUrl;
            await _memberRepository.CreateAsync(member);
            await _memberRepository.SaveChanges();

        }

        public async Task DeleteAsync(int id)
        {
            Member member = await _memberRepository.GetByIdAsync(x => x.Id == id);

            if (member == null) throw new InvalidReferenceException();

           
            string fullPath = Path.Combine(_env.WebRootPath, "Uploads/Members", member.ImageUrl);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            _memberRepository.Delete(member);
            await _memberRepository.SaveChanges();
        }

        public async Task<IEnumerable<MemberGetDto>> GetAllAsync()
        {
            IEnumerable<Member> members = await _memberRepository.GetAllAsync(x => x.IsDeleted == false, "Profession");

            IEnumerable<MemberGetDto> workerGetDtos = members.Select(x => new MemberGetDto 
            { 
              Name = x.Name, 
              ImageUrl = x.ImageUrl,
              RedirectUrl = x.RedirectUrl,
              Id = x.Id });

            return workerGetDtos;
        }

        public async Task<MemberGetDto> GetByIdAsync(int id)
        {
            Member member = await _memberRepository.GetByIdAsync(x => x.Id == id, "Profession");

            if (member == null) throw new InvalidReferenceException();

            MemberGetDto memberGetdto = _mapper.Map<MemberGetDto>(member);
            

            return memberGetdto;
        }

        public async Task ToggleDelete(int id)
        {
            Member member = await _memberRepository.GetByIdAsync(x => x.Id == id);

            if (member == null) throw new InvalidReferenceException();

            member.IsDeleted = !member.IsDeleted;
            member.DeletedDate = DateTime.UtcNow.AddHours(4);

            await _memberRepository.SaveChanges();
        }

        public async Task UpdateAsync([FromForm] MemberUpdateDto memberUpdateDto)
        {
            Member member = await _memberRepository.GetByIdAsync(x => x.Id == memberUpdateDto.Id);
            if (member == null) throw new InvalidReferenceException();

            if (memberUpdateDto.ImageFile != null)
            {
                if (memberUpdateDto.ImageFile.ContentType != "image/png" && memberUpdateDto.ImageFile.ContentType != "image/jpeg")
                {
                    throw new InvalidContentTypeException("file must be  .jpg or .png!");
                }

                if (memberUpdateDto.ImageFile.Length > 1048576)
                {
                    throw new InvalidImagesizeException("file size must be lower than 1mb!");
                }


                string ImgUrl = Helper.SaveFile(_env.WebRootPath, "uploads/Members", memberUpdateDto.ImageFile);

                string path = Path.Combine(_env.WebRootPath, "Uploads/Members", member.ImageUrl);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                member.ImageUrl = ImgUrl;

            }
            member = _mapper.Map(memberUpdateDto, member);

            await _memberRepository.SaveChanges();
        }
    }
}
