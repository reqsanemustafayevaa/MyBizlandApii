using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.DTOs.AccountDto
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.FullName)
               .NotEmpty().WithMessage("Bos ola bilmez!")
               .NotNull().WithMessage("Null ola bilmez!")
               .MaximumLength(30).WithMessage("Max 30 ola biler!")
               .MinimumLength(6).WithMessage("Min 6 ola biler!");

            RuleFor(x => x.UserName)
             .NotEmpty().WithMessage("Bos ola bilmez!")
             .NotNull().WithMessage("Null ola bilmez!")
             .MaximumLength(30).WithMessage("Max 30 ola biler!")
             .MinimumLength(3).WithMessage("Min 3 ola biler!");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Bos ola bilmez!")
            .NotNull().WithMessage("Null ola bilmez!")
            .MaximumLength(30).WithMessage("Max 30 ola biler!")
            .MinimumLength(10).WithMessage("Min 10 ola biler!");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Bos ola bilmez!")
            .NotNull().WithMessage("Null ola bilmez!")
            .MaximumLength(30).WithMessage("Max 30 ola biler!")
            .MinimumLength(8).WithMessage("Min 8 ola biler!");
        }
    }
}
