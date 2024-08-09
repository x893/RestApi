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
		public async Task<ActionResult<IEnumerable<ViewNode>>> GetRootNodes()
		{
			if (dbContext.ViewNodes == null)
			{
				return NotFound();
			}
			return await dbContext.ViewNodes.ToListAsync();
		}

		// public async Task<ActionResult<IEnumerable<ViewNode>>> GetChildNodes(int id)
		[HttpGet("{id}/childs")]
		public IEnumerable<ViewNode>? GetChildNodes(int id)
		{
			var nodes = dbContext.SP_GetNodesByID(id);
			if (nodes == null)
			{
				return null;
			}
			return nodes;
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<ViewNode>> GetNode(int id)
		{
			if (dbContext.Nodes == null)
			{
				return NotFound();
			}
			Node? node = await dbContext.Nodes.FindAsync(id);
			if (node == null)
			{
				return NotFound();
			}

			ViewNode vn = new ViewNode
			{
				Id = node.Id,
				Name = node.Name,
				ParentId = node.ParentId
			};
			return vn;
		}
	}
}
