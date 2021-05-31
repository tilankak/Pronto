using System;
using System.IO;
using System.Windows.Forms;

namespace ErrorLog
{
  public  class Logger
    {
        string appName;
        private string strDefErrPath ;
        public Logger(string AppDataPath, string AppName)
        {
            appName = AppName;
            strDefErrPath = AppDataPath + "\\ErrorLog.txt";
            createNewlog(strDefErrPath);

        }
      
        private void createNewlog(string strErrPath = null, bool isReset = false)
        {
            try
            {
                if (strErrPath == null) { strErrPath = strDefErrPath; }
                //System.Diagnostics.Debugger.Launch();

                string strDateStamp = System.DateTime.Now + " : " + " New Session Started____________________________";
                if (File.Exists(strErrPath) == true && isReset == false)
                {
                    try
                    {
                        using (StreamWriter sr = File.AppendText(strErrPath))
                        {
                            sr.WriteLine(strDateStamp);

                        }
                    }
                    catch (Exception)
                    {
                        CreateNewFile(strErrPath, strDateStamp);
                    }

                }
                else
                {
                    CreateNewFile(strErrPath, strDateStamp);

                }
            }
            catch (Exception) { }
        }

        private  void CreateNewFile(string strErrPath, string strDateStamp, bool isDelExist = false)
        {
            try
            {
                //if(System.IO.Directory.Exists()
                if (System.IO.File.Exists(strErrPath) == true)
                { System.IO.File.Delete(strErrPath); }


                using (StreamWriter sw = File.CreateText(strErrPath))
                {
                    sw.WriteLine(strDateStamp);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message + " - Cannot Create log file", appName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        public  void WriteToErroLog(string strError, string strErrPath = null)
        {
            try
            {
                if (strErrPath == null) { strErrPath = strDefErrPath; }
                strError = DateTime.Now + " : " + strError;
                using (StreamWriter sr = File.AppendText(strErrPath))
                {
                    sr.WriteLine(strError);
                }
            }
            catch (Exception)
            {

            }
        }


        public  void OpenErroLog(string strErrPath = null)
        {
            try
            {
                if (strErrPath == null) { strErrPath = strDefErrPath; }
                System.Diagnostics.Process.Start(strErrPath);
            }
            catch (Exception) { }
        }


        public  void LogError(Exception Ex)
        {
            try
            {

                WriteToErroLog(Ex.ToString());
            }
            catch (Exception)
            {

            }
        }

        public void LogError(string Message, Exception Ex)
        {
            try
            {

                WriteToErroLog(Message + " | " + Ex.ToString());
            }
            catch (Exception)
            {

            }
        }


        public void LogEvent(string DocName,string DocID,string Operation,string User)
        {
            WriteToErroLog(string.Format("Document-{0} ID -{1} {2} User-{3}",DocName,DocID,Operation,User));
        }
        public  void LogDebug(string Message)
        {
            try
            {
                //if (Properties.Settings.Default.Debug)
                //{
                //    WriteToErroLog(Message);
                //}
            }
            catch (Exception)
            {

            }
        }


    }
}
