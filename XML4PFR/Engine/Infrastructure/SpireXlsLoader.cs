using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using das.Extensions.Adapter.Loaders;
using Spire.Xls;

namespace XML4PFR.Engine.Infrastructure
{
    public class SpireXlsLoader : TableLoader
    {
        public override Dictionary<string, DataTable> Parse(string file)
        {
            Dictionary<string, DataTable> result = new Dictionary<string, DataTable>();

            Workbook workbook = new Workbook();

            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                workbook.LoadFromStream(stream);
            }

            foreach (Worksheet worksheet in workbook.Worksheets.Cast<Worksheet>().Where(ws => !ws.IsEmpty))
            {
                result.Add(worksheet.Name, worksheet.ExportDataTable(worksheet.Range, false));
            }

            return result;
        }
    }
}
