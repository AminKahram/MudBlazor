using System.Globalization;
using System.Reflection;

public static class DateExtensionMethods
{
    private static CultureInfo _culture;

    public static CultureInfo GetPersianCulture()
    {
        const string cultureName = "fa-IR";

        if (_culture == null)
        {
            _culture = new CultureInfo(cultureName);

            DateTimeFormatInfo formatInfo = _culture.DateTimeFormat;

            formatInfo.AbbreviatedDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            formatInfo.DayNames = new[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنجشنبه", "جمعه", "شنبه" };
            var monthNames = new[]
            {
                "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن",
                "اسفند",
                ""
            };
            formatInfo.AbbreviatedMonthNames = formatInfo.MonthNames = formatInfo.MonthGenitiveNames = formatInfo.AbbreviatedMonthGenitiveNames = monthNames;

            _culture.DateTimeFormat = new CultureInfo("en-US").DateTimeFormat;

            Calendar persianCalendar = new PersianCalendar();

            FieldInfo fieldInfo = _culture.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
                fieldInfo.SetValue(_culture, persianCalendar);

            FieldInfo info = formatInfo.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
            if (info != null)
                info.SetValue(formatInfo, persianCalendar);

            _culture.NumberFormat.NumberDecimalSeparator = "/";
            _culture.NumberFormat.DigitSubstitution = DigitShapes.NativeNational;
            _culture.NumberFormat.NumberNegativePattern = 0;
        }
        return _culture;
    }
    public static CultureInfo GetGregorianCulture()
    {
        const string cultureName = "en-US";

        if (_culture == null)
        {
            _culture = new CultureInfo(cultureName);

            DateTimeFormatInfo formatInfo = _culture.DateTimeFormat;

            formatInfo.AbbreviatedDayNames = new[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            formatInfo.DayNames = new[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            formatInfo.MonthNames = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "" };

            _culture.DateTimeFormat = new CultureInfo("en-US").DateTimeFormat;

            Calendar gregorianCalendar = new GregorianCalendar();

            FieldInfo fieldInfo = _culture.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
                fieldInfo.SetValue(_culture, gregorianCalendar);

            FieldInfo info = formatInfo.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
            if (info != null)
                info.SetValue(formatInfo, gregorianCalendar);
        }
        return _culture;
    }
}