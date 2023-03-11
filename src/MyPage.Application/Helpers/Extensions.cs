namespace MyPage.Application.Helpers
{
    public static class Extensions
    {
        public static T ToEnum<T>(this string value) 
            => (T)Enum.Parse(typeof(T), value.ToUpper(), true);
    }
}
