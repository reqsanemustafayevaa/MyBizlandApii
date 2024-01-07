using FluentValidation;
using project.business.DTOs.MemberDto;

namespace project.business.DTOs.CategoryDto
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
    }
    public class MemberCreateDtoValidator : AbstractValidator<MemberCreateDto>
    {
        public MemberCreateDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Bosh ola bilmez!")
               .NotNull().WithMessage("Null ola bilmez!")
               .MaximumLength(30).WithMessage("Max 30 ola biler!")
               .MinimumLength(3).WithMessage("Min 3 ola biler!");
        }
    }
}
