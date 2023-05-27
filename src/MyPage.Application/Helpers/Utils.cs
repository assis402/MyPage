namespace MyPage.Application.Helpers
{
    public static class Utils
    {
        public static int MonthDifference(this DateTime firstDate, DateTime secondDate)
        {
            return (secondDate.Month - firstDate.Month) + 12 * (secondDate.Year - firstDate.Year);
        }
    }
}