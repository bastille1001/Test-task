using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskApp.ExceptionHandler
{
    public class CustomError : Exception
    {
        public CustomError(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
