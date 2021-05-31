using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.Sql;

namespace Pronto.Common.Data
{
   public class SqlDataAccess : DataAccess
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
            
            return System.Configuration.ConfigurationManager.ConnectionStrings["ProntoDB"].ToString();  
        }

        public override List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new System.Data.SqlClient.SqlConnection(LoadConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public override void RunScript(string sql)
        {
            using (IDbConnection cnn = new System.Data.SqlClient.SqlConnection(LoadConnectionString()))
            {
                cnn.Open();
                cnn.Execute(sql);

            }
        }

        public override int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new System.Data.SqlClient.SqlConnection (LoadConnectionString()))
            {
                
                cnn.Open();
                return cnn.Execute(sql, data);

            }
        }

        public  int SaveDataAndGetIdentity<T>(string sql, T data)
        {
            using (IDbConnection cnn = new System.Data.SqlClient.SqlConnection(LoadConnectionString()))
            {
                cnn.Open();
                return cnn.Query<int>(sql, data).Single();

            }
        }

        public int RunScriptToResult(string Sql)
        {
            using (IDbConnection cnn = new System.Data.SqlClient.SqlConnection(LoadConnectionString()))
            {
                var result = cnn.Query(Sql).FirstOrDefault();

                if(result == null || result.ID == null)
                { return 1000000; }

                return result.ID;
                //return ((Dapper.SqlMapper.DapperRow)result).values[0];
            }
        }

        public DataTable RunScriptToTable(string Sql)
        {
            using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(LoadConnectionString()))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(Sql,cnn))
                {
                    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }
        }


    }
}
