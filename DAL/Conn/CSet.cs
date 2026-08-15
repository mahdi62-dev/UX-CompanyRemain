using System;

namespace DAL
{
    public class CSet
    {
        public static int AppID;

        public static string cnStringHIS;
        public static string cnStringERP;
        public static string cnStringReport;
        public static string cnStringMasih;


        public static void SetCon(string serverName, string appID)
        {
            AppID = Convert.ToInt32(appID);
            string drowssap = null;

            switch (appID)
            {
                case "1":
                    drowssap = "Alfa@2020#";
                    break;
                case "2":
                    drowssap = "Masih@2024#";
                    break;
            }
            
            cnStringMasih = "Data source=" + serverName +
                          "; Database=Masih; Integrated Security=False;Persist Security Info=True;User ID=sa; Password=" +
                          drowssap + "; Connect Timeout=180;Encrypt=False;";
        }
    }
}