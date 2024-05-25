namespace Student.Api.Interfaces;
public interface IStudentRepository
{
    Task<IEnumerable<Models.Student>> GetAllAsync();
    Task<Models.Student> GetByIdAsync(int id);
    Task<int> AddAsync(Models.Student student);
    Task<int> UpdateAsync(Models.Student student);
    Task<int> DeleteAsync(int id);
}
