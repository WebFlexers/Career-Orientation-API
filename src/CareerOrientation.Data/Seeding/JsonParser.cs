using System.Reflection;
using Newtonsoft.Json;

namespace CareerOrientation.Data.Seeding;

public static class JsonParser
{
    public static async Task<T?> GetJsonContentFromAssemblyAsync<T>(string jsonFileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = assembly.GetManifestResourceNames()
            .First(name => name.Contains(jsonFileName));

        using Stream stream = assembly.GetManifestResourceStream(resourceName)!;
        using StreamReader reader = new StreamReader(stream);

        return JsonConvert.DeserializeObject<T>(await reader.ReadToEndAsync())!;
    }
}