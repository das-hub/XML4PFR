using System;
using das.Data.Annotation;
using XML4PFR.Engine.Infrastructure;

namespace XML4PFR.Models
{
    public class ValidationRecordCsv : Record, IValidationRecord
    {
        public string Id => $"{Index:000000}";
        [Column(1), Snils, SnilsView] public string Snils { get; set; }
        [Column(2), Length(40)] public string Surname { get; set; }
        [Column(3), Length(40)] public string Name { get; set; }
        [Column(4), LengthOrEmpty(40)] public string MiddleName { get; set; }
        [Column(5), Required] public DateTime Birthday { get; set; }
        [Column(6), Values("0", "1", "М", "Ж"), GenderView] public string Gender { get; set; }
    }
}
