using Entitiess.DTO;
using FluentValidation;

namespace B.L.ValidationRules.FluentValidation
{
    public class CategoriesValidation : AbstractValidator<CategoriesDto>
    {
        public CategoriesValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Name).MaximumLength(180).WithMessage("180 Karakterden Fazla Olamaz.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Boş Bırakılamaz.");
        }
    }    
}
