using FluentValidation;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Store.Application.Store.Commands.CreateStore
{
    public class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreCommandValidator(IStoreRepository repository)
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Name should have atleast 2 characters")
                .MaximumLength(20).WithMessage("Name should have maxium of 20 characters")
                .Custom((value, context) =>
                {
                    var stores = repository.GetAll();

                    // TODO: Sprawdzić  czy inny warsztat nie posiada takiej samej nazwy
                });

            RuleFor(s => s.City)
                .NotEmpty().WithMessage("Please enter name the city");

            RuleFor(s => s.PhoneNumber)
                .NotEmpty()
                .NotNull().WithMessage("Phone Number is required.")
                .MinimumLength(8).WithMessage("PhoneNumber must not be less than 10 characters.")
                .MaximumLength(11).WithMessage("PhoneNumber must not exceed 11 characters.");
        }
    }
}