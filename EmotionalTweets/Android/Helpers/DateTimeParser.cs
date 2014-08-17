using System;
using System.Globalization;

namespace EmotionalTweetsAndroid.Helpers
{
    public class DateTimeParser : IDateTimeParser
    {
        public string GetTimeSince(string twitterDate)
        {
            const string format = "ddd MMM dd HH:mm:ss zzzz yyyy";
            var date = DateTime.ParseExact(twitterDate, format, new DateTimeFormatInfo());

            var hoursAgo = (DateTime.Now - date).TotalHours;
            if (hoursAgo < 1)
                return "less than 1 hour ago";

            return ((int)hoursAgo) + "h ago";
        }
    }
}