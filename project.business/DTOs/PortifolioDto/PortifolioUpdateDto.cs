using FluentValidation;

namespace project.business.DTOs.PortifolioDto
{
    public class PortifolioUpdateDto
    {
        public int Id {  get; set; }
        public string Description { get; set; }

        public int CategoryId {  get; set; }
        public string Category { get; set; }
    }
    public class PortifolioUpdateDtoValidator : AbstractValidator<PortifolioUpdateDto>
    {
        public PortifolioUpdateDtoValidator()
        {
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("Bosh ola bilmez!")
               .NotNull().WithMessage("Null ola bilmez!")
               .MaximumLength(30).WithMessage("Max 30 ola biler!")
               .MinimumLength(3).WithMessage("Min 3 ola biler!");
        }
    }
}
