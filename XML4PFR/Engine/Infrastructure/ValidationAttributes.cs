using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using XML4PFR.Extensions;

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
            if (value is string s && _validValues.Any(v => v.Equals(s, StringComparison.InvariantCultureIgnoreCase)))
                    return ValidationResult.Success;
            return new ValidationResult($"Для поля {context.MemberName} допустимые значения [{string.Join(", ", _validValues)}]");
        }
    }

    public class SnilsAttribute : ValidationAttribute
    {
        private readonly Regex _pattern = new Regex("\\d{11}");

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            string snils = value as string;

            if (snils.IsNullOrEmpty()) return ValidationResult.Success;

            Match match = _pattern.Match(snils.Clean());
            
            return match.Success ? ValidationResult.Success : new ValidationResult($"Поле СНИЛС должно содержать только 11 цифр, текущее значение [{snils}]");
        }
    }
}
