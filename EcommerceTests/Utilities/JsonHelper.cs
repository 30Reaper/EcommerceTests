using System.Text.Json;

namespace EcommerceTests.Utilities
{
    public static class JsonHelper
    {
        public static T ReadJsonFile<T>(string fileName)
        {
            var json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException($"Unable to deserialize JSON from {fileName}");
        }
    }
}