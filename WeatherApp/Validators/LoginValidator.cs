using FluentValidation;
using WeatherApp.Models;

namespace WeatherApp.Validators
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please enter your email address.")
                                 .EmailAddress().WithMessage("Email is not a valid format.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter a password.");

        }
    }
}
