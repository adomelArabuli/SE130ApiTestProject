using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SE130ApiTestProject.Data;
using SE130ApiTestProject.Data.Dto.Lector;
using SE130ApiTestProject.Data.Models;
using SE130ApiTestProject.Interfaces;

namespace SE130ApiTestProject.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class LectorController : ControllerBase
	{
		private readonly ILectorService _lectorService;

		public LectorController(ILectorService lectorService)
		{
			_lectorService = lectorService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Lector>>>> GetLectorsAsync()
		{
			var result = await _lectorService.GetLectorsAsync();
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceResponse<Lector>>> GetLectorDetailsAsync(int id)
		{
			var result = await _lectorService.GetLectorDetailsAsync(id);
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}
						 
		[HttpPost]		 
		public async Task<ActionResult<ServiceResponse<Lector>>> CreateLectorAsync(LectorCreateDTO model)
		{
			var result = await _lectorService.CreateLectorAsync(model);
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}
						 
		[HttpPut]		 
		public async Task<ActionResult<ServiceResponse<Lector>>> UpdateLectorAsync(LectorUpdateDTO model)
		{
			var result = await _lectorService.EditLectorAsync(model);
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ServiceResponse<Lector>>> DeleteLectorAsync(int id)
		{
			var result = await _lectorService.DeleteLectorAsync(id);
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}
	}
}
