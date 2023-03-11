﻿namespace MyPage.Application.Helpers
{
    public static class Utils
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value.ToUpper(), true);
        }
    }
}
