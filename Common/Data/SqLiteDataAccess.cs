using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Configuration;
using Dapper;
using System.IO;

namespace Pronto.Common
{
    //public class SqLiteDataAccess : DataAccess
    //{
    //    string databasePath = "";
    //    public SqLiteDataAccess()
    //    {
    //        databasePath = Pronto.Utility.ProjectPaths.DatabasePath;
    //    }

    //    public override void CreateDb(string FilePath)
    //    {
    //        SQLiteConnection.CreateFile(FilePath);
    //    }

    //    public override void CreateTable(string sql)
    //    {
    //        using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
    //        {
    //            cnn.Open();
    //            SQLiteCommand cmd = new SQLiteCommand(sql, cnn);
    //            cmd.ExecuteNonQuery();
    //            cnn.Close();
    //        }
    //    }

    //    public override void RunScript(string sql)
    //    {
    //        using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
    //        {
    //            cnn.Open();
    //            SQLiteCommand cmd = new SQLiteCommand(sql, cnn);
    //            cmd.ExecuteNonQuery();
    //            cnn.Close();
    //        }
    //    }

    //    public override string LoadConnectionString()
    //    {
    //        var con = string.Format("Data Source={0}", databasePath);// ConfigurationManager.ConnectionStrings["SqliteConnection"].ConnectionString;
    //        ConnectionString = con;
    //        Validate(DataSource);
    //        return con + ";Version=3";
    //    }

    //    public override List<T> LoadData<T>(string sql)
    //    {

    //        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
    //        {
    //            return cnn.Query<T>(sql).ToList();
    //        }

    //    }



    //    public override int SaveData<T>(string sql, T data)
    //    {
    //        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
    //        {
    //            cnn.Open();
    //            return cnn.Execute(sql, data);

    //        }
    //    }

    //    private bool Validate(string dbPath)
    //    {
    //        if (!File.Exists(dbPath))
    //        {
    //            CreateDb(dbPath);

    //            foreach (var item in Tables)
    //            {
    //                CreateTable(item);
    //            }

    //        }
    //        return true;
    //    }


    //    private string[] Tables
    //    {
    //        get
    //        {
    //            string script = Properties.Resources.TableScript;
    //            return script.Split('!');
    //        }
    //    }
    //}
}
