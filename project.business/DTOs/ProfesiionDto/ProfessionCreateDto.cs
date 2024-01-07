using FluentValidation;

namespace project.business.DTOs.ProfesiionDto
{
    public class ProfessionCreateDto
    {
        public string Name { get; set; }
    }
    public class ProfessionCreateDtoValidator : AbstractValidator<ProfessionCreateDto>
    {
        public ProfessionCreateDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Bosh ola bilmez!")
               .NotNull().WithMessage("Null ola bilmez!")
               .MaximumLength(30).WithMessage("Max 30 ola biler!")
               .MinimumLength(3).WithMessage("Min 3 ola biler!");
        }
    }
}
