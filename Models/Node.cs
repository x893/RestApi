using System;
using System.Collections.Generic;

namespace RestApi.Models;

public partial class Node
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Node> InverseParent { get; set; } = new List<Node>();

    public virtual Node? Parent { get; set; }
}
