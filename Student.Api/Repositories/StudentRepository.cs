using Dapper;
using MySql.Data.MySqlClient;
using Student.Api.Interfaces;

public class StudentRepository : IStudentRepository
{
    private readonly string _connectionString;

    public StudentRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Student.Api.Models.Student>> GetAllAsync()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return await connection.QueryAsync<Student.Api.Models.Student>("SELECT * FROM Students");
        }
    }

    public async Task<Student.Api.Models.Student> GetByIdAsync(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            return await connection.QueryFirstOrDefaultAsync<Student.Api.Models.Student>("SELECT * FROM Students WHERE Id = @Id", new { Id = id });
        }
    }

    public async Task<int> AddAsync(Student.Api.Models.Student student)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            var sql = "INSERT INTO Students (Name, Age, Email) VALUES (@Name, @Age, @Email)";
            return await connection.ExecuteAsync(sql, student);
        }
    }

    public async Task<int> UpdateAsync(Student.Api.Models.Student student)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            var sql = "UPDATE Students SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, student);
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            var sql = "DELETE FROM Students WHERE Id = @Id";
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
