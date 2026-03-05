using TeacherDesk.Models;

namespace TeacherDesk.Services
{
    public interface IStorageService
    {
        void Save(Sequence sequence);
        Sequence? Load(Guid id);
        List<Sequence> LoadAll();
        void Delete(Guid id);
    }
}