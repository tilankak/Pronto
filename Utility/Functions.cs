using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pronto.Utility
{
   public class Functions
    {

        public static bool isPathContainDirectory(string FilePath)
        {
            string dirName = Path.GetDirectoryName(FilePath);
            return !string.IsNullOrEmpty(dirName);
        }

        public static DateTime StringToDate(string DateString)
        {
            try
            {
                DateTime dateValue;
                if (DateTime.TryParse(DateString, out dateValue))
                {
                    return dateValue;
                }
                return DateTime.Now;
            }
            catch (Exception)
            {

                return DateTime.Now;
            }
        }

        public static int StringToInt(string intString)
        {
            try
            {
               int intValue;
                if (int.TryParse(intString, out intValue))
                {
                    return intValue;
                }
                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public static double StringToDouble(string intString)
        {
            try
            {
                double Value;
                if (double.TryParse(intString, out Value))
                {
                    return Value;
                }
                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
