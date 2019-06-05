using System;
using System.ComponentModel.DataAnnotations;
using das.Extensions.Adapter;
using das.Extensions.Adapter.Annotation;
using XML4PFR.Engine.Infrastructure;

namespace XML4PFR.Models
{
    public class ValidationRecordCsv : Record, IValidationRecord
    {
        public string Id => $"{Index:000000}";
        [Bind(1), Required, Snils, SnilsFormatting] public string Snils { get; set; }
        [Bind(2), MaxLength(40)] public string Surname { get; set; }
        [Bind(3), MaxLength(40)] public string Name { get; set; }
        [Bind(4), MaxLength(40)] public string MiddleName { get; set; }
        [Bind(5), Required] public DateTime Birthday { get; set; }
        [Bind(6), Values("0", "1", "М", "Ж"), GenderFormatting] public string Gender { get; set; }
    }
}
