using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().MinimumLength(3);
            RuleFor(p => p.UnitPrice).NotEmpty().GreaterThan(0);
            RuleFor(p => (int)p.UnitsInStock).NotEmpty().GreaterThan(0);
            RuleFor(p => p.CategoryId).NotEmpty();
        }
    }
}
