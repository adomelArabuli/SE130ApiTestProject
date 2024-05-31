using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SE130ApiTestProject.Data;
using SE130ApiTestProject.Interfaces;
using SE130ApiTestProject.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

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

			builder.Services.AddSwaggerGen(c =>
			{
				c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
				{
					Description = "Standard authorization header using the bearer scheme, e.g \"bearer {token} \"",
					In = ParameterLocation.Header,
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});

				c.OperationFilter<SecurityRequirementsOperationFilter>();
			});

			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
					.GetBytes(builder.Configuration.GetSection("Token:Secret").Value)),
					ValidateIssuer = false,
					ValidateAudience = false
				});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}