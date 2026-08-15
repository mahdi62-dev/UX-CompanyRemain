using System;
using System.Globalization;

namespace APP
{
    public class SDate
    {
        public DateTimeOffset S2MOffsetDate(string sDate)
        {
            //if (sDate == null) return new();
            PersianCalendar persianCalendar = new PersianCalendar();

            string year = sDate.Substring(0, 4);
            string month = sDate.Substring(5, 2);
            string day = sDate.Substring(8, 2);

            //string hour = sDate.Substring(sDate.IndexOf(' ')+1, 1);
            //string minute = sDate.Substring(sDate.IndexOf(':')+1, 2);
            //string second= sDate.Substring(sDate.LastIndexOf(':')+1, 2);

            DateTime dateTime = persianCalendar.ToDateTime(Convert.ToInt32(year), Convert.ToInt32(month),
                Convert.ToInt32(day), 0, 0, 0, 0);
            //string date1 = dateTime.ToString();

            return new DateTimeOffset(dateTime, DateTimeOffset.Now.Offset);
        }

        public string MOffsetDate2S(DateTimeOffset? mDateOffset)
        {
            DateTime mDate = mDateOffset.Value.DateTime;

            PersianCalendar pc = new PersianCalendar();

            string sdate, year, month, day, hour, min;

            year = pc.GetYear(mDate).ToString();

            if (pc.GetDayOfMonth(mDate).ToString().Length == 1)
            {
                day = "0" + pc.GetDayOfMonth(mDate);
            }
            else
            {
                day = pc.GetDayOfMonth(mDate).ToString();
            }

            if (pc.GetMonth(mDate).ToString().Length == 1)
            {
                month = "0" + pc.GetMonth(mDate);
            }
            else
            {
                month = pc.GetMonth(mDate).ToString();
            }

            sdate = year + "/" + month + "/" + day;
            return sdate;
        }

        public string ShamsiDate()
        {
            DateTime now = DateTime.Now;
            PersianCalendar PC = new PersianCalendar();

            string year, month, day, hour, min, sdate;

            year = PC.GetYear(now).ToString();

            if (PC.GetDayOfMonth(now).ToString().Length == 1)
            {
                day = "0" + PC.GetDayOfMonth(now);
            }
            else
            {
                day = PC.GetDayOfMonth(now).ToString();
            }

            if (PC.GetMonth(now).ToString().Length == 1)
            {
                month = "0" + PC.GetMonth(now);
            }
            else
            {
                month = PC.GetMonth(now).ToString();
            }

            if (PC.GetHour(now).ToString().Length == 1)
            {
                hour = "0" + PC.GetHour(now);
            }
            else
            {
                hour = PC.GetHour(now).ToString();
            }

            if (PC.GetMinute(now).ToString().Length == 1)
            {
                min = "0" + PC.GetMinute(now);
            }
            else
            {
                min = PC.GetMinute(now).ToString();
            }

            return year + "/" + month + "/" + day;
        }

        public string ShamsiDateTime()
        {
            DateTime now = DateTime.Now;
            PersianCalendar PC = new PersianCalendar();

            string year, month, day, hour, min, sdate;

            year = PC.GetYear(now).ToString();

            if (PC.GetDayOfMonth(now).ToString().Length == 1)
            {
                day = "0" + PC.GetDayOfMonth(now);
            }
            else
            {
                day = PC.GetDayOfMonth(now).ToString();
            }

            if (PC.GetMonth(now).ToString().Length == 1)
            {
                month = "0" + PC.GetMonth(now);
            }
            else
            {
                month = PC.GetMonth(now).ToString();
            }

            if (PC.GetHour(now).ToString().Length == 1)
            {
                hour = "0" + PC.GetHour(now);
            }
            else
            {
                hour = PC.GetHour(now).ToString();
            }

            if (PC.GetMinute(now).ToString().Length == 1)
            {
                min = "0" + PC.GetMinute(now);
            }
            else
            {
                min = PC.GetMinute(now).ToString();
            }

            return year + "/" + month + "/" + day + " " + hour + ":" + min;
        }

        public string AddDate(int days)
        {
            DateTime now = DateTime.Now;
            now = now.AddDays(days);

            PersianCalendar PC = new PersianCalendar();

            string year, month, day, hour, min, sdate;

            year = PC.GetYear(now).ToString();

            if (PC.GetDayOfMonth(now).ToString().Length == 1)
            {
                day = "0" + PC.GetDayOfMonth(now);
            }
            else
            {
                day = PC.GetDayOfMonth(now).ToString();
            }

            if (PC.GetMonth(now).ToString().Length == 1)
            {
                month = "0" + PC.GetMonth(now);
            }
            else
            {
                month = PC.GetMonth(now).ToString();
            }

            if (PC.GetHour(now).ToString().Length == 1)
            {
                hour = "0" + PC.GetHour(now);
            }
            else
            {
                hour = PC.GetHour(now).ToString();
            }

            if (PC.GetMinute(now).ToString().Length == 1)
            {
                min = "0" + PC.GetMinute(now);
            }
            else
            {
                min = PC.GetMinute(now).ToString();
            }

            return year + "/" + month + "/" + day;
        }
    }
}