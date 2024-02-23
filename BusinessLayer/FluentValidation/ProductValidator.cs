using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alanı Boş geçemezsiniz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 Karakter Olmalıdır.");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stock alanı boş geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş geçilemez");

        }
    }
}
