﻿using Entitiess.DTO;
using FluentValidation;
using System.Text.RegularExpressions;

namespace B.L.ValidationRules.FluentValidation
{
    public class OrdersValidation : AbstractValidator<OrdersUpdateDto>
    {
        public OrdersValidation()
        {
            RuleFor(x => x.CustomersId).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.CargoNumber).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.CargoNumber).MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz.");
            RuleFor(x => x.CargoNumber).Must(NumberControl).WithMessage("Kargo Bilgisi Doğru Girilmedi.");           
            RuleFor(x => x.CargoPrice).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.OrderStatus).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.OrderStatus).MaximumLength(30).WithMessage("30 Karakterden Fazla Olamaz.");
            RuleFor(x => x.TotalPrice).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Kdv).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.TotalDiscount).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.CouponPrice).NotEmpty().WithMessage("Boş Bırakılamaz.");
        }
        private bool NumberControl(string data)
        {
            Regex regex = new Regex(@"^[0-9]{10}$");
            return regex.IsMatch(data.ToString());
        }
    }
}
