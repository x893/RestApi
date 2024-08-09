using System;
using System.Collections.Generic;

namespace RestApi.Models;

public partial class ViewNode
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string? Name { get; set; }

    public int? ChildCount { get; set; }
}
