using MVCformNupat.Data;
using MVCformNupat.Model;

namespace MVCformNupat.Repository
{
    public class StudentService : IRepository
    {
        private AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
        }

        public IEnumerable<Student> GetAllStudent()
        {
           return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Where(q => q.Id == id).FirstOrDefault();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }
    }
}
