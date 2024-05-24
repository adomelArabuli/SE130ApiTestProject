using SE130ApiTestProject.Data.Models;
using SE130ApiTestProject.Data;
using SE130ApiTestProject.Data.Dto.Student;

namespace SE130ApiTestProject.Interfaces
{
	public interface IStudentService
	{
		Task<ServiceResponse<ICollection<Student>>> GetStudentsAsync();
		Task<ServiceResponse<Student>> GetStudentDetailsAsync(int id);
		Task<ServiceResponse<bool?>> CreateStudentAsync(StudentCreateDTO model);
		Task<ServiceResponse<ICollection<Student>>> EditStudentAsync(StudentUpdateDTO model);
		Task<ServiceResponse<bool?>> DeleteStudentAsync(int id);
	}
}
