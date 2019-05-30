using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XML4PFR.Engine.Requests;
using XML4PFR.Extensions;
using XML4PFR.Models;

namespace XML4PFR.Engine.Builders
{
    public class ValidationRequestBuilder : RequestBuilder
    {
        private readonly IEnumerable<IValidationRecord> _records;

        public ValidationRequestBuilder(string file, IEnumerable<IValidationRecord> records, string provider, int fileNumber, int size) : base(file, provider, fileNumber, size)
        {            
            _records = records;
        }

        public override void BuildTo(string path)
        {
            path = Directory.CreateDirectory(Path.Combine(path, "VALIDATIONS", _provider)).FullName;

            RaiseInformation($"Начинаю конвертацию [{_file}]");

            int count = _records.Count();

            double parts = Math.Ceiling(Convert.ToDouble(count) / Convert.ToDouble(_size));

            RaiseInformation($" Будет обработано записей: {count}");
            RaiseInformation($" Будет создано частей: {parts}");

            ValidationRequest request;

            int part = 0;
            do
            {
                string fileName = $"VALIDATION-REQ-012-{_provider}-{_fileNumber:00}-{(part + 1):000}.XML";

                RaiseInformation($" Формируется файл [{fileName}]");

                var items = _records.Skip(part * _size).Take(_size);
                count = items.Count();

                RaiseInformation($"  Будет добавлено записей: {count}");

                request = new ValidationRequest(fileName, count);

                items.Do(r =>
                {
                    ValidationItem item = request.AddNewItem();

                    item.ID = $"012-{_provider}-{r.Id}";
                    item.Snils = r.Snils;
                    item.Surname = r.Surname;
                    item.Name = r.Name;
                    item.MiddleName = r.MiddleName;
                    item.Birthday = r.Birthday.ToString("dd.MM.yyyy");
                    item.Gender = r.Gender;
                });

                RaiseInformation($"Создан файл [{request.SaveTo(path)}]");

                part++;

            } while (part < parts);

            RaiseComplete("Конвертация выполнена успешно");
        }
    }
}
