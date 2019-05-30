using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XML4PFR.Engine.Requests;
using XML4PFR.Extensions;
using XML4PFR.Models;

namespace XML4PFR.Engine.Builders
{
    public class IdentificationRequestBuilder : RequestBuilder
    {
        private readonly IEnumerable<IIdentificationRecord> _records;

        public IdentificationRequestBuilder(string file, IEnumerable<IIdentificationRecord> records, string provider, int fileNumber, int size) : base(file, provider, fileNumber, size)
        {
            _records = records;
        }

        public override void BuildTo(string path)
        {
            path = Directory.CreateDirectory(Path.Combine(path, "IDENTIFICATION", _provider)).FullName;

            RaiseInformation($"Начинаю конвертацию [{_file}]");

            int count = _records.Count();

            double parts = Math.Ceiling(Convert.ToDouble(count) / Convert.ToDouble(_size));

            RaiseInformation($" Будет обработано записей: {count}");
            RaiseInformation($" Будет создано частей: {parts}");

            IdentificationRequest request;

            int part = 0;
            do
            {
                string fileName = $"IDENTIFICATION-REQ-012-{_provider}-{_fileNumber:00}-{(part + 1):000}.XML";

                RaiseInformation($" Формируется файл [{fileName}]");

                var items = _records.Skip(part * _size).Take(_size);
                count = items.Count();

                RaiseInformation($"  Будет добавлено записей {count}");

                request = new IdentificationRequest(fileName, count);

                items.Do(r =>
                {
                    IdentificationItem item = request.AddNewItem();

                    item.ID = $"012-{_provider}-{r.Id}";
                    item.Name = r.Name;
                    item.Surname = r.Surname;
                    item.MiddleName = r.MiddleName;
                    item.Birthday = r.Birthday.ToString("dd.MM.yyyy");
                    item.Gender = r.Gender;

                    item.PlaceOfBirth.Country = r.Сountry;
                    item.PlaceOfBirth.Region = r.Region;
                    item.PlaceOfBirth.Area = r.Area;
                    item.PlaceOfBirth.City = r.City;

                });

                RaiseInformation($"Создан файл [{request.SaveTo(path)}]");

                part++;

            } while (part < parts);

            RaiseComplete("Конвертация выполнена успешно");
        }
    }
}
