using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Validators
{
    public class ContactUsValidator : AbstractValidator<ContactUsModel>
    {

        public ContactUsValidator()
        {

            RuleFor(x => x.FullName).NotEmpty().WithMessage("Please enter your full name.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please enter an email address.")
                                 .EmailAddress().WithMessage("Please enter valid email address.");
            RuleFor(x => x.Feedback).NotEmpty().WithMessage("Please provide feedback message.")
                                    .MaximumLength(301).WithMessage("Message must be less then 300 characters.");
        }

    }
}




