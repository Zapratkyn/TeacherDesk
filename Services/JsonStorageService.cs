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

        public void Save(Sequence sequence)
        {
            string filePath = Path.Combine(_dataPath, $"{sequence.Id}.json");
            string json = JsonSerializer.Serialize(sequence, _options);
            File.WriteAllText(filePath, json);
        }

        public Sequence? Load(Guid id)
        {
            string filePath = Path.Combine(_dataPath, $"{id}.json");
            
            if (!File.Exists(filePath))
                return null;
                
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Sequence>(json);
        }

        public List<Sequence> LoadAll()
        {
            var sequences = new List<Sequence>();
            
            foreach (string file in Directory.GetFiles(_dataPath, "*.json"))
            {
                string json = File.ReadAllText(file);
                Sequence? sequence = JsonSerializer.Deserialize<Sequence>(json);
                
                if (sequence is not null)
                    sequences.Add(sequence);
            }
            
            return sequences;
        }

        public void Delete(Guid id)
        {
            string filePath = Path.Combine(_dataPath, $"{id}.json");
            
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}