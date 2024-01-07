using FluentValidation;

namespace project.business.DTOs.PortifolioDto
{
    public class PortifolioCreateDto
    {
        
        public string Description { get; set; }
       

        public string Category { get; set; }
        public int CategotyId {  get; set; }
        

    }
    public class PortifolioCreateValidator : AbstractValidator<PortifolioCreateDto>
    {
        public PortifolioCreateValidator()
        {
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("Bosh ola bilmez!")
               .NotNull().WithMessage("Null ola bilmez!")
               .MaximumLength(30).WithMessage("Max 30 ola biler!")
               .MinimumLength(3).WithMessage("Min 3 ola biler!");
        }
    }
}
