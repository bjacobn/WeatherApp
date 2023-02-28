using FluentValidation;
using WeatherApp.Models;

namespace WeatherApp.Validators
{
    public class ContactUsValidator : AbstractValidator<ContactUsModel>
    {

        public ContactUsValidator()
        {

            RuleFor(x => x.FullName).NotEmpty().WithMessage("Please enter your full name.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please enter an email address.")
                                 .EmailAddress().WithMessage("Please enter a valid email address.");
            RuleFor(x => x.Feedback).NotEmpty().WithMessage("Please provide a message.")
                                    .MaximumLength(301).WithMessage("Message must be less then 300 characters.");
        }
    }
}




