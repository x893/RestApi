using System.ComponentModel.DataAnnotations;

namespace RestApi.Models
{
	public class Node
	{
		[Key]
		public int Id { get; set; }
		public int? ParentId { get; set; }
		[MaxLength(50)]
		public string? Name { get; set; }
	}
}
