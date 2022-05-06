using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public ValidationException() : base("There was one or many validation issues.")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> errors) : this()
        {
            foreach (var error in errors) 
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
