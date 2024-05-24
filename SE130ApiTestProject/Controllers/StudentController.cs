using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SE130ApiTestProject.Data.Models;
using SE130ApiTestProject.Data;
using SE130ApiTestProject.Interfaces;
using SE130ApiTestProject.Services;
using SE130ApiTestProject.Data.Dto.Lector;
using SE130ApiTestProject.Data.Dto.Student;

namespace SE130ApiTestProject.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Student>>>> GetStudentsAsync()
		{
			var result = await _studentService.GetStudentsAsync();
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceResponse<Student>>> GetStudentDetailsAsync(int id)
		{
			var result = await _studentService.GetStudentDetailsAsync(id);
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<Student>>> CreateStudentAsync(StudentCreateDTO model)
		{
			var result = await _studentService.CreateStudentAsync(model);
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<Lector>>> UpdateStudentAsync(StudentUpdateDTO model)
		{
			var result = await _studentService.EditStudentAsync(model);
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ServiceResponse<bool>>> DeleteStudentAsync(int id)
		{
			var result = await _studentService.DeleteStudentAsync(id);
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}
	}
}
