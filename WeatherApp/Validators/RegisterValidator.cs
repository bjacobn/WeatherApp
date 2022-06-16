using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterModel>
    {
        private readonly IRegisterRepository regRepo;

        public RegisterValidator(IRegisterRepository regRepo)
        {
            this.regRepo = regRepo;

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please enter your first name.");  
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please enter your last name.");  
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                                 .EmailAddress().WithMessage("Valid email address is required.")
                                 .Must(BeUniqueEmail).WithMessage("Email is already registered.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter a password.")
                                    .MinimumLength(6).WithMessage("Password must be 6 or more characters");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Confirmation Password does not match.");

            
            //Custom Validator
            bool BeUniqueEmail(string email)
            {                
                return regRepo.IsEmailExist(email);             
            }
        }     
    }
}
