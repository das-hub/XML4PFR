using System.Text.RegularExpressions;
using das.Extensions.Adapter.Annotation;
using XML4PFR.Extensions;

namespace XML4PFR.Engine.Infrastructure
{
    public class SnilsFormatting : FormattingAttribute
    {
        private readonly Regex _regex;

        public SnilsFormatting()
        {
            _regex = new Regex(@"(\d{3})(\d{3})(\d{3})(\d{2})");
        }

        public override object Format(object value)
        {
            string s = value as string;
            return _regex.Replace(s.Clean(), "$1-$2-$3 $4");
        }
    }

    public class GenderFormatting : FormattingAttribute
    {
        public override object Format(object value)
        {
            string s = value as string;

            switch (s)
            {
                case "0":
                    return "М";
                case "1":
                    return "Ж";
                default:
                    return s.ToUpper();
            }
        }
    }
}
