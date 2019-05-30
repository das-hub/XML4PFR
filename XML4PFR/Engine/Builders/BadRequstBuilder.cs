using System.Collections.Generic;
using System.Linq;
using das.Extensions.Adapter;
using XML4PFR.Extensions;

namespace XML4PFR.Engine.Builders
{
    public class BadRequstBuilder : RequestBuilder
    {
        private readonly IEnumerable<Record> _records;

        public BadRequstBuilder(string file, IEnumerable<Record> records) : base(file, "", 0, 0)
        {
            _records = records;
        }

        public override void BuildTo(string path)
        {
            RaiseError($"Во время обработки [{_file}] были обнаружены ошибки в данных, в [{_records.Count()}] строках");

            _records.Do(i => RaiseError(i.Errors));

            RaiseError("Необходимо устранить все найденные ошибки и повторить конвертацию.");

            RaiseComplete("Конвертация не выполнена (см. лог программы)");
        }
    }
}
