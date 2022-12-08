using CapstoneAPI.Data;
using CapstoneAPI.Models;
using CapstoneAPI.Repo.IRepo;

namespace CapstoneAPI.Repo
{
    public class StudentRepo : Repo<Student>, IStudentRepo
    {
        private readonly ApplicationDbContext _db;
        public StudentRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Student> UpdateAsync(Student entity)
        {
            
            _db.Students.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
