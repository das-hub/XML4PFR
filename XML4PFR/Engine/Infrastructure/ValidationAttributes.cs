using System;
using System.Linq;
using System.Text.RegularExpressions;
using das.Data.Annotation;

namespace XML4PFR.Engine.Infrastructure
{
    public class LengthAttribute : ValidateAttribute
    {
        private readonly int _length;

        public LengthAttribute(int length)
        {
            _length = length;
            ErrorMessage = $"Длина поля не должна превышать [{_length}] символов";
        }

        public override bool IsValid(object value)
        {
            if (value is string s)
                return s.Length <= _length;
            return false;
        }
    }

    public class LengthOrEmptyAttribute : ValidateAttribute
    {
        private readonly int _length;

        public LengthOrEmptyAttribute(int length)
        {
            _length = length;
            ErrorMessage = $"Поле должно быть пустым или длина поля не должна превышать [{_length}] символов";
        }

        public override bool IsValid(object value)
        {
            if (value is string s)
                return string.IsNullOrEmpty(s) || s.Length <= _length;
            return false;
        }
    }

    public class SnilsAttribute : LengthAttribute
    {
        private readonly Regex _regex;

        public SnilsAttribute() : base(11)
        {            
            _regex = new Regex(@"-|\s+");
            ErrorMessage = $"Длина поля СНИЛС должна быть равна 11 символов";
        }

        public override bool IsValid(object value)
        {
            if (value is string s)            
                return base.IsValid(_regex.Replace(s, string.Empty));
            return false;
        }
    }

    public class RequiredAttribute : ValidateAttribute
    {
        public RequiredAttribute()
        {
            ErrorMessage = "Поле является обязательным к заполнению";
        }

        public override bool IsValid(object value)
        {
            if (value is string s)
                return !string.IsNullOrEmpty(s);
            if (value is DateTime dt)
                return dt != DateTime.MinValue;
            return false;
        }
    }

    public class ValuesAttribute : ValidateAttribute
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
