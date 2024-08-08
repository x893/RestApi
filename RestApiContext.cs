using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi
{
	public class RestApiContext:DbContext
	{
		public RestApiContext(DbContextOptions<RestApiContext> options) : base(options)
		{
		}
		public DbSet<Node> Nodes { get; set; } = null!;
	}
}
