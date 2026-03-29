using TeacherDesk.Models;
using System;
using System.Collections.Generic;

namespace TeacherDesk.Services
{
    public sealed class ServiceLocator
    {
        private static string _dataPath = "./data";
        private static readonly Lazy<ServiceLocator> _instance = 
            new(() => new ServiceLocator(_dataPath));
        
        public static ServiceLocator Instance => _instance.Value;
        
        private readonly IStorageService _storage;
        private readonly Dictionary<Guid, IStorable> _cache;

        /// <summary>
        /// Initialise le chemin de données avant la première utilisation du ServiceLocator
        /// </summary>
        public static void Initialize(string dataPath)
        {
            if (_instance.IsValueCreated)
                throw new InvalidOperationException("ServiceLocator est déjà initialisé. Appelez Initialize() avant d'accéder à Instance.");
            
            _dataPath = dataPath;
        }

        private ServiceLocator(string dataPath)
        {
            _storage = new JsonStorageService(dataPath);
            _cache = new Dictionary<Guid, IStorable>();
        }

        // Accès au service de stockage
        public IStorageService Storage => _storage;

        // Méthodes de cache
        public void CacheAdd(IStorable item)
        {
            if (item != null)
                _cache[item.Id] = item;
        }

        public void CacheAddRange(IEnumerable<IStorable> items)
        {
            foreach (var item in items)
                CacheAdd(item);
        }

        public bool TryGetFromCache(Guid id, out IStorable? item)
        {
            return _cache.TryGetValue(id, out item);
        }

        public IStorable? GetFromCache(Guid id)
        {
            _cache.TryGetValue(id, out var item);
            return item;
        }

        public void RemoveFromCache(Guid id)
        {
            _cache.Remove(id);
        }

        public void ClearCache()
        {
            _cache.Clear();
        }

        public int CacheSize => _cache.Count;
    }
}
