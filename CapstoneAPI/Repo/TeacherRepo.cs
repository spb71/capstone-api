using CapstoneAPI.Data;
using CapstoneAPI.Models;
using CapstoneAPI.Repo.IRepo;

namespace CapstoneAPI.Repo
{
    public class TeacherRepo : Repo<Teacher>, ITeacherRepo
    {
        private readonly ApplicationDbContext _db;
        public TeacherRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Teacher> UpdateAsync(Teacher entity)
        {
            
            _db.Teachers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
