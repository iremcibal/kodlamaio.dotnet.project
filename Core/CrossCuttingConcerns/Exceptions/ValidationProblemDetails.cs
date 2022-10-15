using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ValidationProblemDetails : ExceptionProblemDetailsBase
    {
        public object Errors { get; set; }
    }
}
