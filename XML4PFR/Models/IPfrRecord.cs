using System;

namespace XML4PFR.Models
{
    public interface IPfrRecord
    {
        string Surname { get; set; }
        string Name { get; set; }
        string MiddleName { get; set; }
        DateTime Birthday { get; set; }
        string Gender { get; set; }
    }

    public interface IValidationRecord : IPfrRecord
    {
        string Id { get;}
        string Snils { get; set; }
    }

    public interface IIdentificationRecord : IPfrRecord
    {
        string Id { get; }
        string City { get; set; }
        string Area { get; set; }
        string Region { get; set; }
        string Сountry { get; set; }
    }
}
