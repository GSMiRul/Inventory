using Application.Brands.Commands.DeleteBrand;
using FluentValidation;

namespace Application.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(b => b.Id)
                .NotEmpty()
                .WithMessage("Brand Id can't be empty");
        }
    }
}
