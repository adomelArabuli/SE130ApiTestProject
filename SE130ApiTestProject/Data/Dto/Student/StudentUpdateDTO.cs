namespace SE130ApiTestProject.Data.Dto.Student
{
	public class StudentUpdateDTO
	{
        public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfbirth { get; set; }
		public bool IsMale { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
        public int LectorId { get; set; }
    }
}
