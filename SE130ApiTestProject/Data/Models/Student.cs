namespace SE130ApiTestProject.Data.Models
{
	public class Student : Person
	{
        public ICollection<Lector> Lectors { get; set; }
    }
}
