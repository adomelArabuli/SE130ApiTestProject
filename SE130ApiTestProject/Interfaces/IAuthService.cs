using SE130ApiTestProject.Data;
using SE130ApiTestProject.Data.Dto.User;

namespace SE130ApiTestProject.Interfaces
{
	public interface IAuthService
	{
		Task<ServiceResponse<int>> Register(UserRegisterDTO model);
		Task<ServiceResponse<string>> Login(UserLoginDTO model);
	}
}
