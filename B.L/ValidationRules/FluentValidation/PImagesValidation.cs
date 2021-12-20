﻿using Entitiess.DTO;
using FluentValidation;

namespace B.L.ValidationRules.FluentValidation
{
    public class PImagesValidation : AbstractValidator<PImagesDto>
    {
        public PImagesValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz.");
            RuleFor(x => x.ProductsId).NotEmpty().WithMessage("Boş Bırakılamaz.");
        }
    }
}
