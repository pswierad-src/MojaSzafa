using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MojaSzafa.Data
{
    public class DateLesserThanOrEqueal : ValidationAttribute
    {      

        public override string FormatErrorMessage(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return "Date can't be greater than today";
            }
            else
            {
                return base.FormatErrorMessage(name);
            }
            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = value as DateTime? ?? new DateTime();
            if (date.Date > DateTime.Now.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}
