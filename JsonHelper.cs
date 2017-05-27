using Newtonsoft.Json;

namespace SyUtilsCore
{
    public class JsonHelper
    {
        public static string ToJson(object obj, params JsonConverter[] converters)
        {
            return JsonConvert.SerializeObject(obj, converters);
        }

        public static T FromJson<T>(string json, params JsonConverter[] converters)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);

            return JsonConvert.DeserializeObject<T>(json, converters);
        }
    }
}