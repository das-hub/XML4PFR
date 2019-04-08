using System.Collections.Generic;
using System.Linq;
using das.Data.Adapter;
using XML4PFR.Engine.Builders;
using XML4PFR.Models;

namespace XML4PFR.Engine.Handlers
{
    public class ValidationCsvStrategy : IStrategy
    {
        public RequestBuilder Handler(string file, string provider, int fileNumber)
        {
            ObjectAdapter adapter = FileAdapter.Csv(file);
            IEnumerable<ValidationRecordCsv> records = adapter.Records<ValidationRecordCsv>(true);
            
            if (records.Any(r => !r.IsValid))
                return new BadRequstBuilder(file, records.Where(r => !r.IsValid));

            return new ValidationRequestBuilder(file, records.Where(r => r.IsValid), provider, fileNumber, 10000);
        }

        public string Filter => "Файлы CSV|*.csv";
    }
}
