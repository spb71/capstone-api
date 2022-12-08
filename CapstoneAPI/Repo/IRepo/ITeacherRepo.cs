using CapstoneAPI.Models;

namespace CapstoneAPI.Repo.IRepo
{
    public interface ITeacherRepo: IRepo<Teacher>
    {
        Task<Teacher> UpdateAsync(Teacher entity);
    }
    
}
