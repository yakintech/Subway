using FluentValidation;

namespace Subway.UI.Models.dto
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(q => q.Name).NotEmpty().WithMessage("Name alanı boş bırakılamaz");

        }
    }
}
