using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarDetailValidation : AbstractValidator<CarDetailsDto>
    {
        public CarDetailValidation()
        {
            RuleFor(cd => cd.CarName).NotEmpty();
            RuleFor(cd => cd.BrandName).NotEmpty();
            RuleFor(cd => cd.ColorName).NotEmpty();
            RuleFor(cd => cd.DailyPrice).NotEmpty();
            RuleFor(cd => cd.DailyPrice).GreaterThanOrEqualTo(0);

        }
    }
}
