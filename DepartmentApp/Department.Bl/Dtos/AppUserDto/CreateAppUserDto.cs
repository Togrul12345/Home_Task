using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Department.Bl.Dtos.AppUserDto
{
    public class CreateAppUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public  string Email { get; set; }


       

    }
    public  class CreateAppUserValidation : AbstractValidator<CreateAppUserDto>
    {
        public CreateAppUserValidation()
        {
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().WithMessage("Phone number couldnt be null").Must(a=>IsValidPhoneNumber(a)).WithMessage("enter phonenumber in correct format");
            RuleFor(a => a.Password).Equal(a => a.ConfirmPassword).WithMessage("Password and confirmPassword are not same");
           
           
        }
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex rgx = new Regex(@"^\+994(50|51|55|70|77)\d{7}$");
           Match match= rgx.Match(phoneNumber);
            if (match.Success)
            {
                return true;
            }
            return false;
        }
    }
}
