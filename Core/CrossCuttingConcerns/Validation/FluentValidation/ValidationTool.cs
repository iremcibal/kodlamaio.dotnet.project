using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool<T>
    {
        public static void Validate(Type validatorType,T request){
            if(!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception();
            var validator = (IValidator)Activator.CreateInstance(validatorType);
            var context = new ValidationContext<T>(request);
            var result = validator.Validate(context);
            if(!result.IsValid)
                throw new ValidationException(result.Errors);

           
        }
    }
}
