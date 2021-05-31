using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pronto.Common.Data
{
    public class CSVDataAccess : DataAccess
    {
        public override void CreateDb(string FilePath)
        {
            throw new NotImplementedException();
        }

        public override void CreateTable(string sql)
        {
            throw new NotImplementedException();
        }

        public override string LoadConnectionString()
        {
            throw new NotImplementedException();
        }

        public override List<T> LoadData<T>(string CSVPath)
        {
            throw new NotImplementedException();

        }

        public override void RunScript(string sql)
        {
            throw new NotImplementedException();
        }

        public override int SaveData<T>(string sql, T data)
        {
            throw new NotImplementedException();
        }

        public List<string> ReadCsv(string CSVpath)
        {
            using (var reader = new StreamReader(CSVpath))
            {
                List<string> listA = new List<string>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);

                }

                return (listA);
            }
        }
    }
}
