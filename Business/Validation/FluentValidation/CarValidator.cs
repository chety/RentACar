using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name.Length).NotNull().GreaterThan(2).WithMessage(Messages.CarNameInValid);
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.CarPriceInValid);
        }
    }
}
