using System.Xml.Linq;

namespace XML4PFR.Engine.Requests
{
    public class IdentificationRequest : PfrRequest<IdentificationItem>
    {
        public IdentificationRequest(string fileName, int countRecord): base(fileName, countRecord, "ИДЕНТИФИКАЦИЯ_ЗАПРОС") { }            

        public override IdentificationItem AddNewItem()
        {
            XElement e = new XElement("Идентификация_запрос",
                new XElement("ИдентификаторЗапроса", ""),
                new XElement("Фамилия", ""),
                new XElement("Имя", ""),
                new XElement("Отчество", ""),
                new XElement("ДатаРождения", ""),
                new XElement("Пол", ""),
                new XElement("МестоРождения",
                    new XElement("ГородРождения", ""),
                    new XElement("РайонРождения", ""),
                    new XElement("ОбластьРождения", ""),
                    new XElement("СтранаРождения", "")));

            _context.Root.Add(e);

            return new IdentificationItem(e);
        }
    }

    public class IdentificationItem : PfrItem
    {
        public IdentificationItem(XElement context) : base(context) {}

        public PlaceOfBirth PlaceOfBirth => new PlaceOfBirth(_context.Element("МестоРождения"));
    }

    public class PlaceOfBirth
    {
        private readonly XElement _context;

        public PlaceOfBirth(XElement context)
        {
            _context = context;
        }

        public string City
        {
            get => (string)_context.Element("ГородРождения").Value;
            set => _context.Element("ГородРождения").Value = value;
        }

        public string Area
        {
            get => (string)_context.Element("РайонРождения").Value;
            set => _context.Element("РайонРождения").Value = value;
        }

        public string Region
        {
            get => (string)_context.Element("ОбластьРождения").Value;
            set => _context.Element("ОбластьРождения").Value = value;
        }

        public string Country
        {
            get => (string)_context.Element("СтранаРождения").Value;
            set => _context.Element("СтранаРождения").Value = value;
        }
    }
}
