namespace SE130ApiTestProject.Data.Models
{
	public class User
	{
        public int Id { get; set; }
		public string UserName { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
        public string? RefreshToken { get; set; }
		public ICollection<Role> Roles { get; set; }

    }
}
