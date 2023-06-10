using MyPage.Application.CustomAttributes;

namespace MyPage.Application.Helpers
{
    public static class Utils
    {
        public static int MonthDifference(this DateTime firstDate, DateTime secondDate)
        {
            return (secondDate.Month - firstDate.Month) + 12 * (secondDate.Year - firstDate.Year);
        }

        public static string GetCollectionName<TEntity>() where TEntity : class
        {
            var attribute = (CollectionAttribute)Attribute.GetCustomAttribute(typeof(TEntity), typeof(CollectionAttribute));
            return attribute.CollectionName;
        }
    }
}