using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Models;

public partial class RestApiContext : DbContext
{
    public RestApiContext()
    {
    }

    public RestApiContext(DbContextOptions<RestApiContext> options)
        : base(options)
    {
    }

	public virtual DbSet<ViewNode> ChildNodes { get; set; }

	public virtual DbSet<Node> Nodes { get; set; }

    public virtual DbSet<ViewNode> ViewNodes { get; set; }

	public IEnumerable<ViewNode> SP_GetNodesByID(int id)
	{
		return ChildNodes
			.FromSqlInterpolated($"[dbo].[GetNodesByID] {id}")
			.ToArray();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>(entity =>
        {
            entity.HasIndex(e => e.ParentId, "IX_Nodes_ParentId");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Nodes_Root");
        });

		modelBuilder.Entity<ViewNode>(entity =>
        {
		    entity.HasKey(e => e.Id);
    		entity
                .ToView("ViewNode");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
