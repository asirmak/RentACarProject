using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(2010).When(c=>c.BrandId == 2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.Description).Must(StartWithUygun).WithMessage("Description must start with keyword 'Uygun'");
        }

        private bool StartWithUygun(string arg)
        {
            return arg.StartsWith("Uygun");
        }
    }
}
