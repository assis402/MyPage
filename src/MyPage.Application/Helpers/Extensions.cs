using Newtonsoft.Json;

namespace MyPage.Application.Helpers
{
    public static class Extensions
    {
        public static T ToEnum<T>(this string value)
            => (T)Enum.Parse(typeof(T), value.ToUpper(), true);

        public static string ToJson(this object obj)
            => JsonConvert.SerializeObject(obj);

        public static bool IsNotNullOrEmpty(this string text)
            => !string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text);

        public static string Captalize(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return char.ToUpper(value[0]) + value[1..];
        }
    }
}