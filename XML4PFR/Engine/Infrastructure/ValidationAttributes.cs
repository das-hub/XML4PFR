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
            ErrorMessage = $"Допустимые значения для поля [{string.Join(", ", validValues)}]";
        }

        public override bool IsValid(object value)
        {
            if (value is string s)
                return _validValues.Any(v => v.Equals(s, StringComparison.InvariantCultureIgnoreCase));
            return false;
        }
    }
}
