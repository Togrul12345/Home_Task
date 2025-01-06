using Final.Bl.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Validators
{
    public class CreateAppUserValidator:AbstractValidator<CreateAppUser>
    {
        public CreateAppUserValidator()
        {
            RuleFor(a => a.Password).Equal(a => a.ConfirmPassword).WithMessage("Password and ConfirmPassword Must be same");
            RuleFor(a => a.FirstName).MaximumLength(30).WithMessage("Firstname cannot be greater than 30");
            RuleFor(a => a.LastName).MaximumLength(30).WithMessage("Lastname cannot be greater than 30");
            
        }
    }
}
