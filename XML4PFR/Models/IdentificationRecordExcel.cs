using System;
using das.Data.Annotation;
using XML4PFR.Engine.Infrastructure;

namespace XML4PFR.Models
{
    public class IdentificationRecordExcel : Record, IIdentificationRecord
    {
        public string Id => $"{Index:000000}";
        [Column(1), Length(40)] public string Surname { get; set; }
        [Column(2), Length(40)] public string Name { get; set; }
        [Column(3), LengthOrEmpty(40)] public string MiddleName { get; set; }
        [Column(4), Required] public DateTime Birthday { get; set; }
        [Column(5), Values("0", "1", "М", "Ж"), GenderView] public string Gender { get; set; }
        [Column(6), LengthOrEmpty(40)] public string City { get; set; }
        [Column(7), LengthOrEmpty(40)] public string Area { get; set; }
        [Column(8), LengthOrEmpty(40)] public string Region { get; set; }
        [Column(9), LengthOrEmpty(40)] public string Сountry { get; set; }
    }
}
