using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Pronto.Common
{
    public abstract class DataAccess
    {
        public abstract string LoadConnectionString();

       
        public abstract List<T> LoadData<T>(string sql);
        public abstract int SaveData<T>(string sql, T data);

        public abstract void CreateDb( string FilePath);

        public abstract void CreateTable(string sql);
        public abstract void RunScript(string sql);

        

       protected string ConnectionString;

        public string DataSource
        {
            get
            {
                if (!string.IsNullOrEmpty(ConnectionString))
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString);
                    return builder.DataSource; 
                }
                else
                { return null; }
            }
        }
    }
}
