namespace SE130ApiTestProject.Data.Models
{
	public class Student : Person
	{
        public Student()
        {
            Lectors = new List<Lector>();
        }
        public ICollection<Lector> Lectors { get; set; }
    }
}
