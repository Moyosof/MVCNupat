using MVCformNupat.Model;

namespace MVCformNupat.Repository
{
    public interface IRepository
    {
        IEnumerable<Student> GetAllStudent();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
        Task SaveAsync();
    }
}
