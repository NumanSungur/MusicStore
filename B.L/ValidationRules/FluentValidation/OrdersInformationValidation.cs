using Entitiess.DTO;
using FluentValidation;

namespace B.L.ValidationRules.FluentValidation
{
    public class OrdersInformationValidation : AbstractValidator<OrderInformationsDto>
    {
        public OrdersInformationValidation()
        {
            RuleFor(x => x.Sms).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Message).MaximumLength(150).WithMessage("150 Karakterden Fazla Olamaz.");
            RuleFor(x => x.InfoDate).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.OrdersId).NotEmpty().WithMessage("Boş Bırakılamaz.");
        }
    }
}
