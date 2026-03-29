using System.Text.Json;

namespace EcommerceTests.Utilities
{
    public static class JsonHelper
    {
        public static T ReadJson<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}