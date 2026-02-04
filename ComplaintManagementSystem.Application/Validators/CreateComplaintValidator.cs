using ComplaintManagementSystem.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Application.Validators
{
    public class CreateComplaintValidator : AbstractValidator<CreateComplaintDto>
    {
        public CreateComplaintValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
