using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(b => b.brandName)
                .NotEmpty()
                .WithMessage("Brand can't be empty")
                .MaximumLength(100)
                .WithMessage("Brand name should be less than {MaxLenght} characters");
        }
    }
}
