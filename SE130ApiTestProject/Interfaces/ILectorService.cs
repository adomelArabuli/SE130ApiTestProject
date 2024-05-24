using SE130ApiTestProject.Data;
using SE130ApiTestProject.Data.Dto.Lector;
using SE130ApiTestProject.Data.Models;

namespace SE130ApiTestProject.Interfaces
{
    public interface ILectorService
	{
		Task<ServiceResponse<ICollection<Lector>>> GetLectorsAsync();
		Task<ServiceResponse<Lector>> GetLectorDetailsAsync(int id);
		Task<ServiceResponse<bool?>> CreateLectorAsync(LectorCreateDTO model);
		Task<ServiceResponse<bool?>> EditLectorAsync(LectorUpdateDTO model);
		Task<ServiceResponse<bool?>> DeleteLectorAsync(int id);
	}
}
