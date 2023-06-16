using MyPage.Application.CustomAttributes;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;

namespace MyPage.Application.Helpers
{
    public static class Extensions
    {
        public static T ToEnum<T>(this string value)
            => (T)Enum.Parse(typeof(T), value.ToUpper(), true);

        public static string ToJson(this object obj)
            => JsonConvert.SerializeObject(obj);

        public static TObject ToObject<TObject>(this string obj)
            => JsonConvert.DeserializeObject<TObject>(obj);

        public static bool IsNotNullAndNotEmpty(this string text)
            => !string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text);

        public static string Captalize(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return char.ToUpper(value[0]) + value[1..];
        }

        public static StringBuilder Append(this string @string, string text)
            => new StringBuilder(@string).Append(text);

        public static string Description(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var array = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
            if (array.Length != 0)
            {
                return array[0].Description;
            }

            return value.ToString();
        }
    }
}