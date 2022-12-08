using CapstoneAPI.Data;
using CapstoneAPI.Models;
using CapstoneAPI.Repo.IRepo;

namespace CapstoneAPI.Repo
{
    public class GradeRepo : Repo<Grade>, IGradeRepo
    {
        private readonly ApplicationDbContext _db;
        public GradeRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Grade> UpdateAsync(Grade entity)
        {
            
            _db.Grades.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
