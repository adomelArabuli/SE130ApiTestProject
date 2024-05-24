using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SE130ApiTestProject.Data;
using SE130ApiTestProject.Data.Dto.Lector;
using SE130ApiTestProject.Data.Models;
using SE130ApiTestProject.Interfaces;

namespace SE130ApiTestProject.Services
{
    public class LectorService : ILectorService
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;
		public LectorService(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<ICollection<Lector>>> GetLectorsAsync()
		{
			try
			{
				return new() { Data = await _db.Lectors.ToListAsync() };
			}
			catch (Exception ex)
			{
				return new() { Success = false, Message =  ex.Message};
			}
		}

		public async Task<ServiceResponse<Lector>> GetLectorDetailsAsync(int id)
		{
			try
			{
				var lector = await _db.Lectors.FirstOrDefaultAsync(x => x.Id == id);
				if(lector == null)
					return new() { Success = false, Message = "Lector not found" };
				return new() { Success = true, Data = lector };
			}
			catch (Exception ex)
			{
				return new() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<bool?>> CreateLectorAsync(LectorCreateDTO model)
		{
			try
			{
				var existingLector = await _db.Lectors.FirstOrDefaultAsync(x => x.Email == model.Email);
				if (existingLector != null)
					return new() { Success = false, Message = "Lector with the same email already exists" };

				var lector = _mapper.Map<Lector>(model);
				await _db.Lectors.AddAsync(lector);
				await _db.SaveChangesAsync();

				return new() { Success = true, Data = null };
			}
			catch (Exception ex)
			{
				return new() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<bool?>> EditLectorAsync(LectorUpdateDTO model)
		{
			try
			{
				var lectorToEdit = await _db.Lectors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.Id);
				if (lectorToEdit == null) return new() { Success = false, Message = "Lector not found" };

				_db.Lectors.Update(_mapper.Map<Lector>(model));
				await _db.SaveChangesAsync();
				return new() { Success = true };
			}
			catch (Exception ex)
			{
				return new() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<bool?>> DeleteLectorAsync(int id)
		{
			var lectorToDelete = await _db.Lectors.FirstOrDefaultAsync(x => x.Id == id);

			if (lectorToDelete == null) return new() { Success = false, Message = "Lector not found" };

			_db.Lectors.Remove(lectorToDelete);
			await _db.SaveChangesAsync();

			return new() { Success = true };
		}
	}
}
