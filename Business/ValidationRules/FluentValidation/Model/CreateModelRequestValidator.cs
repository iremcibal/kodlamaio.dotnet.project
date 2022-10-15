using Business.Requests.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Model
{
    public class CreateModelRequestValidator : AbstractValidator<CreateModelRequest>
    {
        public CreateModelRequestValidator()
        {
            RuleFor(m=>m.Name).NotEmpty();
            RuleFor(m => m.Name).MinimumLength(2).WithMessage("Model ismi en az 2 karakter olabilir.");
            RuleFor(m=>m.DailyPrice).NotEmpty();
            RuleFor(m => m.DailyPrice).GreaterThan(0).WithMessage("DailyPrice 0'dan büyük olmalıdır.");
        }
    }
}
