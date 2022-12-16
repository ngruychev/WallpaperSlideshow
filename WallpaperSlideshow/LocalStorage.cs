using System.Text.Json;

namespace WallpaperSlideshow
{
    static internal class LocalStorage
    {
        private static string jsonPath { get => Application.LocalUserAppDataPath + "/localStorage.json"; }

        private static Dictionary<string, string> getAll()
        {
            try
            {
                string rawJson = File.ReadAllText(jsonPath);
                var all = JsonSerializer.Deserialize<Dictionary<string, string>>(rawJson)!;
                if (all == null)
                {
                    return new();
                }
                return all;
            }
            catch (FileNotFoundException)
            {
                return new();
            }
        }

        public static int Length { get => getAll().Count; }

        public static T? Key<T>(int n)
        {
            var keys = getAll().Keys.ToArray();
            if (n > keys.Length)
            {
                return default;
            }
            return GetItem<T>(keys[n]);
        }

        public static T? GetItem<T>(string name)
        {
            var all = getAll();
            // voodoo magic
            // https://stackoverflow.com/a/70848031
            if (!all.TryGetValue(name, out string? jsonStr))
            {
                return default;
            }
            string json = jsonStr;
            return JsonSerializer.Deserialize<T>(json);
        }

        public static void SetItem<T>(string name, T item)
        {
            var json = JsonSerializer.Serialize<T>(item);
            var all = getAll();
            all[name] = json;
            var allJson = JsonSerializer.Serialize(all);
            File.WriteAllText(jsonPath, allJson);
        }

        public static void RemoveItem(string name)
        {
            var all = getAll();
            all.Remove(name);
            var allJson = JsonSerializer.Serialize(all);
            File.WriteAllText(jsonPath, allJson);
        }

        public static void Clear()
        {
            File.Delete(jsonPath);
        }
    }
}
