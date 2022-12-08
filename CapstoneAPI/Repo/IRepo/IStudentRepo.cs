using CapstoneAPI.Models;

namespace CapstoneAPI.Repo.IRepo
{
    public interface IStudentRepo: IRepo<Student>
    {
        Task<Student> UpdateAsync(Student entity);
    }
}
