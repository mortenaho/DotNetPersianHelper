using System.Globalization;

namespace PersianHelper;

public static class DateHelper
{
    public static string ToPersianDate(this DateTime miladiDate, string format = "yyyy/MM/dd")
    {
        // ایجاد یک شیء از کلاس PersianCalendar
        PersianCalendar persianCalendar = new PersianCalendar();
        
        // تبدیل تاریخ میلادی به شمسی
        int year = persianCalendar.GetYear(miladiDate);
        int month = persianCalendar.GetMonth(miladiDate);
        int day = persianCalendar.GetDayOfMonth(miladiDate);
        
        // جایگذاری مقادیر سال، ماه و روز در قالب مورد نظر
        string result = format
            .Replace("yyyy", year.ToString("D4"))
            .Replace("yy", (year % 100).ToString("D2"))
            .Replace("MM", month.ToString("D2"))
            .Replace("dd", day.ToString("D2"))
            .Replace("d", day.ToString())
            .Replace("M", month.ToString());

        return result;
    }
    public static DateTime ToGregorianDate(this string persianDate, string format = "yyyy/MM/dd")
    {
        // ایجاد یک شیء از کلاس PersianCalendar
        PersianCalendar persianCalendar = new PersianCalendar();

        // شناسایی بخش‌های تاریخ براساس فرمت
        int year = 0, month = 0, day = 0;

        // جایگذاری مقادیر سال، ماه و روز براساس فرمت
        if (format.Contains("yyyy"))
        {
            year = int.Parse(persianDate.Substring(format.IndexOf("yyyy"), 4));
        }
        else if (format.Contains("yy"))
        {
            year = int.Parse(persianDate.Substring(format.IndexOf("yy"), 2)) + 1300;
        }

        if (format.Contains("MM"))
        {
            month = int.Parse(persianDate.Substring(format.IndexOf("MM"), 2));
        }
        else if (format.Contains("M"))
        {
            month = int.Parse(persianDate.Substring(format.IndexOf("M"), 1));
        }

        if (format.Contains("dd"))
        {
            day = int.Parse(persianDate.Substring(format.IndexOf("dd"), 2));
        }
        else if (format.Contains("d"))
        {
            day = int.Parse(persianDate.Substring(format.IndexOf("d"), 1));
        }

        // ساخت تاریخ میلادی
        return persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
    }
}