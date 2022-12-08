using CapstoneAPI.Models;

namespace CapstoneAPI.Repo.IRepo
{
    public interface ICourseRepo: IRepo<Course>
    {
        Task<Course> UpdateAsync(Course entity);
    }
    
    
}
