using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace RestApi
{
	public class Program
	{
		/// <summary>
		/// Log error
		/// </summary>
		private static void LogError()
		{

		}

		/// <summary>
		/// Main
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<RestApiContext>(options =>
				options.UseSqlServer((builder.Configuration.GetConnectionString("RestApiContext") ?? string.Empty).Replace("%CONTENTROOTPATH%", Environment.CurrentDirectory))
				);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			WebApplication app = builder.Build();
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				app.UseDeveloperExceptionPage();
			}

			app.UseExceptionHandler(app => app.Run(async context =>
			{
				LogError();
				context.Response.StatusCode = 500;
				await context.Response.WriteAsync("Error 500. Fatal error occurred");
			}));

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
