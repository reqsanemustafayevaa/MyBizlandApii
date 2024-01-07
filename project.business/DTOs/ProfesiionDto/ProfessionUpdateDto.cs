using FluentValidation;

namespace project.business.DTOs.ProfesiionDto
{
    public class ProfessionUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProfessionUpdateDtoValidator : AbstractValidator<ProfessionUpdateDto>
    {
        public ProfessionUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("Bosh ola bilmez!")
              .NotNull().WithMessage("Null ola bilmez!")
              .MaximumLength(30).WithMessage("Max 30 ola biler!")
              .MinimumLength(3).WithMessage("Min 3 ola biler!");
        }
    }
}
