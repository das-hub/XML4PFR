using System.Collections.Generic;
using System.Linq;
using das.Extensions.Adapter;
using XML4PFR.Engine.Builders;
using XML4PFR.Engine.Infrastructure;
using XML4PFR.Models;

namespace XML4PFR.Engine.Handlers
{
    public class ValidationExcelStrategy : IStrategy
    {
        public RequestBuilder Handler(string file, string provider, int fileNumber)
        {
            ObjectAdapter adapter = FileAdapter.Load(file, new SpireXlsLoader());
            IEnumerable<ValidationRecordExcel> records = adapter.Records<ValidationRecordExcel>(true);

            if (records.Any(r => !r.IsValid))
                return new BadRequstBuilder(file, records.Where(r => !r.IsValid));

            return new ValidationRequestBuilder(file, records.Where(r => r.IsValid), provider, fileNumber, 10000);
        }

        public string Filter => "Файлы Excel|*.xls;*.xlsx";
    }
}
