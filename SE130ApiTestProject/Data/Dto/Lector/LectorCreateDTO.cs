namespace SE130ApiTestProject.Data.Dto.Lector
{
    public class LectorCreateDTO
    {
        public string Subject { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfbirth { get; set; }
        public bool IsMale { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
