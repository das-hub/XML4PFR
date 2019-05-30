using System;
using System.ComponentModel.DataAnnotations;
using das.Extensions.Adapter;
using das.Extensions.Adapter.Annotation;
using XML4PFR.Engine.Infrastructure;

namespace XML4PFR.Models
{
    public class IdentificationRecordExcel : Record, IIdentificationRecord
    {
        public string Id => $"{Index:000000}";
        [Bind(1), MaxLength(40)] public string Surname { get; set; }
        [Bind(2), MaxLength(40)] public string Name { get; set; }
        [Bind(3), MaxLength(40)] public string MiddleName { get; set; }
        [Bind(4), Required] public DateTime Birthday { get; set; }
        [Bind(5), Values("0", "1", "М", "Ж"), GenderFormatting] public string Gender { get; set; }
        [Bind(6), MaxLength(40)] public string City { get; set; }
        [Bind(7), MaxLength(40)] public string Area { get; set; }
        [Bind(8), MaxLength(40)] public string Region { get; set; }
        [Bind(9), MaxLength(40)] public string Сountry { get; set; }
    }
}
