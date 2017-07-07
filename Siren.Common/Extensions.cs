using Newtonsoft.Json;
using System;

namespace Siren.Common
{
    public static class Extensions
    {
        public static string ToJson<T>(this T obj, bool minified = true) where T : class
        {
            if (obj == null)
            {
                return null;
            }

            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                Formatting = minified ? Formatting.None : Formatting.Indented,
                NullValueHandling = minified ? NullValueHandling.Ignore : NullValueHandling.Include
            });
        }

        public static T ParseJson<T>(this string s) where T : class
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<T>(s);
        }
    }
}
