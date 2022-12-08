using CapstoneAPI.Data;
using CapstoneAPI.Models;
using CapstoneAPI.Repo.IRepo;

namespace CapstoneAPI.Repo
{
    public class CourseRepo : Repo<Course>, ICourseRepo
    {
        private readonly ApplicationDbContext _db;
        public CourseRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Course> UpdateAsync(Course entity)
        {
            
            _db.Courses.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
