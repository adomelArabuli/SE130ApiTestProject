using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SE130ApiTestProject.Data;
using SE130ApiTestProject.Interfaces;
using SE130ApiTestProject.Services;

namespace SE130ApiTestProject
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers()
				.AddNewtonsoftJson(options =>
				 {
					 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				 });

			builder.Services.AddAutoMapper(typeof(Program).Assembly);

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<IStudentService, StudentService>();
			builder.Services.AddScoped<ILectorService, LectorService>();
			builder.Services.AddScoped<IAuthService, AuthService>();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}