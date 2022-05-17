using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(b => b.brandName)
                .NotEmpty()
                .WithMessage("Brand can't be empty")
                .MaximumLength(100)
                .WithMessage("Brand name should be less than {MaxLenght} characters");
        }
    }
}
