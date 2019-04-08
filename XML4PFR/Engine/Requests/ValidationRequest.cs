using System.Xml.Linq;

namespace XML4PFR.Engine.Requests
{
    public class ValidationRequest : PfrRequest<ValidationItem>
    {
        public ValidationRequest(string fileName, int countItem) : base(fileName, countItem, "ВАЛИДАЦИЯ_ЗАПРОС") { }

        public override ValidationItem AddNewItem()
        {
            XElement e = new XElement("Валидация_запрос",
                new XElement("ИдентификаторЗапроса", ""),
                new XElement("СНИЛС", ""),
                new XElement("Фамилия", ""),
                new XElement("Имя", ""),
                new XElement("Отчество", ""),
                new XElement("ДатаРождения", ""),
                new XElement("Пол", ""));

            _context.Root.Add(e);

            return new ValidationItem(e);
        }
    }

    public class ValidationItem : PfrItem
    {
        public ValidationItem(XElement context) : base(context) { }

        public string Snils
        {
            get => (string)_context.Element("СНИЛС").Value;
            set => _context.Element("СНИЛС").Value = value;
        }
    }
}
