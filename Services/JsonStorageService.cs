using System.Text.Json;
using TeacherDesk.Models;

namespace TeacherDesk.Services
{
    public class JsonStorageService : IStorageService
    {
        private readonly string _dataPath;

        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
        };

        public JsonStorageService(string dataPath)
        {
            _dataPath = dataPath;
            Directory.CreateDirectory(dataPath);
        }

        public void Save<T>(T data) where T : IStorable
        {
            var subPath = Path.Combine(_dataPath, $"{typeof(T).Name}");
            Directory.CreateDirectory(subPath);
            string filePath = Path.Combine(subPath, $"{data.Id}.json");
            string json = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(filePath, json);
        }

        public T? Load<T>(Guid id) where T : IStorable
        {
            string filePath = Path.Combine(_dataPath, $"{typeof(T).Name}", $"{id}.json");
            
            if (!File.Exists(filePath))
                return default;
                
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }

        public List<T> LoadAll<T>() where T : IStorable
        {
            var list = new List<T>();
            var FilesPath = Path.Combine(_dataPath, $"{typeof(T).Name}");

            Directory.CreateDirectory(FilesPath);
            
            foreach (string file in Directory.GetFiles(FilesPath, "*.json"))
            {
                string json = File.ReadAllText(file);
                T? data = JsonSerializer.Deserialize<T>(json);
                
                if (data is not null)
                    list.Add(data);
            }
            
            return list.ToList();
        }

        public void Delete<T>(Guid id) where T : IStorable
        {
            string filePath = Path.Combine(_dataPath, $"{typeof(T).Name}", $"{id}.json");
            
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}