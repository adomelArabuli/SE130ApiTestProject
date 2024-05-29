using System.ComponentModel.DataAnnotations;

namespace SE130ApiTestProject.Data.Dto.User
{
	public class UserRegisterDTO
	{
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
