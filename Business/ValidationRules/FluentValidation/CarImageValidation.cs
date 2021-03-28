using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(ci => ci.ImagePath).NotNull();
            RuleFor(ci => ci.ImagePath).NotEmpty();
        }
    }
}
