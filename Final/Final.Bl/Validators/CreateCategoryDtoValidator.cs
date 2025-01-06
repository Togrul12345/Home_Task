using Final.Bl.Dtos.CategoryDtos;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Validators
{
    public class CreateCategoryDtoValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Cannot be empty").NotNull().WithMessage("Cannot be  null");
            RuleFor(a=>a.Description).NotEmpty().WithMessage("Cannot be empty").NotNull().WithMessage("Cannot be  null");
        }
    }
}
