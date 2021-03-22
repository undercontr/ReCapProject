using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Car>
    {
        public ProductValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).NotNull();

            RuleFor(c => c.Description).MinimumLength(30);
            RuleFor(c => c.Description).NotNull();

            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).MaximumLength(100);
        }
    }
}
