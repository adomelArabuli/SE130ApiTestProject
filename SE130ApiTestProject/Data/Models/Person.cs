namespace SE130ApiTestProject.Data.Models
{
	public class Person
	{
        public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
