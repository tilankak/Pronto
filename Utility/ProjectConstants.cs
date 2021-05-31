using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronto.Utility
{
    public class ProjectConstants
    {
        public const string PROTECTBTN = "protectBtn";
        public const string INFORBTN = "infotBtn";

        public const string PASSWORDKEY = "CFTX&^%$#(*&@??JNVFJ|*{||!!!CFTX";
        public const string ZIPPASSWORDKEY = "CfTSushilZip9955kk%%##*^";

        static string[] extentions = { ".xlsx", ".xls", ".xlsm", ".docx", ".doc", ".docm", ".pptx", ".ppt", ".pptm", ".csv", ".pdf", ".pdfx" };
        static string[] _convertedExt = { ".jpg", ".png", ".txt", ".tiff", ".tif", ".jpeg", ".jpg", ".png", ".gif", ".bmp", ".ico", ".jpc", ".htm", ".html", ".psd" };

        public static bool isConverteNeed(string ext)
        {
            if (extentions.Contains(ext, StringComparer.InvariantCultureIgnoreCase))
            { return false; }
            else
            { return true; }
        }
        public static string[] ConvertedExt
        {
            get
            {
                return _convertedExt;
            }
        }

        public static List<string> AllSupportedExt
        {
            get
            {
                List<string> extlist = extentions.ToList();
                extlist.AddRange(_convertedExt);
                return extlist;
            }
        }


    }
}
