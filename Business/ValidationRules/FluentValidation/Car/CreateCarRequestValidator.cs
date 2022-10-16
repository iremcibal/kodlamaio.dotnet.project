using Business.Requests.Cars;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Car
{
    public class CreateCarRequestValidator : AbstractValidator<CreateCarRequest>
    {
        public CreateCarRequestValidator()
        {
            RuleFor(c => c.ModelYear).Must(beAValidModelYear);
        }

        private bool beAValidModelYear(int arg)
        {
            int currentYear = DateTime.Now.Year;
            int minYear = currentYear - arg;
            if(arg > currentYear)
                throw new Exception();
            if (minYear <= 20)
                return true;
                
            return false;
        }
    }
}
