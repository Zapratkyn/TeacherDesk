using TeacherDesk.Models;

namespace TeacherDesk.Services
{
    public interface IStorageService
    {
        void Save<T>(T data) where T : IStorable;
        T? Load<T>(Guid id) where T : IStorable;
        List<T> LoadAll<T>() where T : IStorable;
        void Delete<T>(Guid id) where T : IStorable;
    }
}