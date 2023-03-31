using Newtonsoft.Json;

namespace MyPage.Application.Helpers
{
    public static class Extensions
    {
        public static T ToEnum<T>(this string value) 
            => (T)Enum.Parse(typeof(T), value.ToUpper(), true);

        public static string ToJson(this object obj)
            => JsonConvert.SerializeObject(obj);

        public static bool IsNotEmpty(this string text)
            => !string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text);
    }
}
