using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace XML4PFR.Engine.Requests
{
    public abstract class PfrRequest<T> where T : PfrItem
    {
        protected readonly XDocument _context;
        protected readonly string _fileName;

        protected PfrRequest(string fileName, int countItem, string type)
        {
            _fileName = fileName;
            _context = new XDocument(new XDeclaration("1.0", "Windows-1251", null),
                new XElement("ФайлПФР",
                    new XElement("ИмяФайла", fileName),
                    new XElement("ДатаФормирования", DateTime.Today.ToString("dd.MM.yyyy")),
                    new XElement("ВерсияФормата", "1.0"),
                    new XElement("ТипФайла", type),
                    new XElement("КоличествоЗаписейВфайле", countItem)));
        }

        public abstract T AddNewItem();

        public string SaveTo(string path)
        {
            using (StringWriterWithEncoding writer = new StringWriterWithEncoding(Encoding.GetEncoding(1251)))
            {
                _context.Save(writer);

                string file = Path.Combine(path, _fileName);

                File.WriteAllText(file, writer.ToString(), Encoding.GetEncoding(1251));

                return file;
            }
        }
    }

    public class PfrItem
    {
        protected readonly XElement _context;

        public PfrItem(XElement context)
        {
            _context = context;
        }

        public string ID
        {
            get => (string)_context.Element("ИдентификаторЗапроса").Value;
            set => _context.Element("ИдентификаторЗапроса").Value = value;
        }

        public string Surname
        {
            get => (string)_context.Element("Фамилия").Value;
            set => _context.Element("Фамилия").Value = value;
        }

        public string Name
        {
            get => (string)_context.Element("Имя").Value;
            set => _context.Element("Имя").Value = value;
        }

        public string MiddleName
        {
            get => (string)_context.Element("Отчество").Value;
            set => _context.Element("Отчество").Value = value;
        }

        public string Birthday
        {
            get => (string)_context.Element("ДатаРождения").Value;
            set => _context.Element("ДатаРождения").Value = value;
        }

        public string Gender
        {
            get => (string)_context.Element("Пол").Value;
            set => _context.Element("Пол").Value = value;
        }
    }

    public class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding _encoding;
        public StringWriterWithEncoding(Encoding encoding)
        {
            _encoding = encoding;
        }

        public override Encoding Encoding
        {
            get { return _encoding; }
        }
    }
}

