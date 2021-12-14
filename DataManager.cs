using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Library
{
    class DataManager : IDataManager
    {

        public List<Book> Load(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Book>>(jsonString);

        }

        public bool Save(List<Book> library, string filePath)
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize<List<Book>>(library, options);
            File.WriteAllText(filePath, jsonString);
            return true;
        }
    }
}