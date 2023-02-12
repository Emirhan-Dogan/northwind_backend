using FluentValidation;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product Name is empty."); // magic stringden kurtulma. formatlı stringler... 
            RuleFor(p => p.UnitPrice).NotEmpty().GreaterThanOrEqualTo(20);
            RuleFor(p => p.UnitPrice).NotEmpty().GreaterThanOrEqualTo(0).When(p => p.CategoryID == 2);
            RuleFor(p => p.UnitsInStock).Must(CheckStock).WithMessage("Stoklar tükendi");
        }

        private bool CheckStock(short arg)
        {
            if (arg == 0)
            {
                return false;
            }
            return true;
        }
    }
}
