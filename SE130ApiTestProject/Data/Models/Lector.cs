namespace SE130ApiTestProject.Data.Models
{
	public class Lector : Person
	{
        public ICollection<Student> Students { get; set; }
        public string Subject { get; set; }
    }
}
