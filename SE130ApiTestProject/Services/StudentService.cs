using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SE130ApiTestProject.Data;
using SE130ApiTestProject.Data.Dto.Student;
using SE130ApiTestProject.Data.Models;
using SE130ApiTestProject.Interfaces;

namespace SE130ApiTestProject.Services
{
	public class StudentService : IStudentService
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;
		public StudentService(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<ICollection<Student>>> GetStudentsAsync()
		{
			try
			{
				return new() { Data = await _db.Students.ToListAsync() };
			}
			catch (Exception ex)
			{
				return new() { Success = false, Message = ex.Message };
			}
		}
		public async Task<ServiceResponse<Student>> GetStudentDetailsAsync(int id)
		{
			try
			{
				var student = await _db.Students.Include(x => x.Lectors).FirstOrDefaultAsync(x => x.Id == id);
				if (student == null)
					return new() { Success = false, Message = "Student not found" };
				return new() { Success = true, Data = student };
			}
			catch (Exception ex)
			{
				return new() { Success = false, Message = ex.Message };
			}
		}
		public async Task<ServiceResponse<bool?>> CreateStudentAsync(StudentCreateDTO model)
		{
			try
			{
				var existingstudent = await _db.Students.FirstOrDefaultAsync(x => x.Email == model.Email);
				if (existingstudent != null)
					return new() { Success = false, Message = "Student with the same email already exists" };

				var student = _mapper.Map<Student>(model);

				if (model.LectorIds != null)
				{
					var lectors = await _db.Lectors.Where(x => model.LectorIds.Contains(x.Id)).ToListAsync();
					student.Lectors = lectors;
				}

				await _db.Students.AddAsync(student);
				await _db.SaveChangesAsync();

				return new() { Success = true, Data = null };
			}
			catch (Exception ex)
			{
				return new() { Success = false, Message = ex.Message };
			}
		}
		public async Task<ServiceResponse<ICollection<Student>>> EditStudentAsync(StudentUpdateDTO model)
		{
			try
			{
				var studentToEdit = await _db.Students.Include(x => x.Lectors).FirstOrDefaultAsync(x => x.Id == model.Id);
				if (studentToEdit == null) return new() { Success = false, Message = "Student not found" };

				_mapper.Map(model,studentToEdit);

				if(model.LectorIds != null)
				{
					var lectors = await _db.Lectors.Where(x => model.LectorIds.Contains(x.Id)).ToListAsync();
					studentToEdit.Lectors = lectors;
				}

				_db.Students.Update(studentToEdit);
				await _db.SaveChangesAsync();
				return new() { Success = true };
			}
			catch (Exception ex)
			{
				return new() { Success = false, Message = ex.Message };
			}
		}
		public async Task<ServiceResponse<bool?>> DeleteStudentAsync(int id)
		{
			var studentToDelete = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);

			if (studentToDelete == null) return new() { Success = false, Message = "Student not found" };

			_db.Students.Remove(studentToDelete);
			await _db.SaveChangesAsync();

			return new() { Success = true };
		}
	}
}
