using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
	[Route("nodes")]
	[ApiController]
	public class NodeController : ControllerBase
	{
		private readonly RestApiContext dbContext;
		public NodeController(RestApiContext context)
		{
			dbContext = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Node>>> GetParentNodes()
		{
			if (dbContext.Nodes == null)
			{
				return NotFound();
			}
			return await dbContext.Nodes.ToListAsync();
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Node>> GetNode(int id)
		{
			if (dbContext.Nodes == null)
			{
				return NotFound();
			}
			var node = await dbContext.Nodes.FindAsync(id);
			if (node == null)
			{
				return NotFound();
			}
			return node;
		}
	}
}
