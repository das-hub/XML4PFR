using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace XML4PFR.Engine.Infrastructure
{
    public class ValuesAttribute : ValidationAttribute
    {
        private readonly string[] _validValues;

        public ValuesAttribute(params string[] validValues)
        {
            _validValues = validValues;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            ErrorMessage = $"Для поля {context.MemberName} допустимые значения [{string.Join(", ", _validValues)}]";

            if (value is string s && _validValues.Any(v => v.Equals(s, StringComparison.InvariantCultureIgnoreCase)))
                    return ValidationResult.Success;
            return new ValidationResult(ErrorMessage);
        }
    }
}
