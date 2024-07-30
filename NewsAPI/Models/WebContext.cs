using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewsAPI.Models;

public partial class WebContext : DbContext
{
    public WebContext(DbContextOptions<WebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsFiles> NewsFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.NewsId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.InsertDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpdateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<NewsFiles>(entity =>
        {
            entity.Property(e => e.NewsFilesId).ValueGeneratedNever();
            entity.Property(e => e.Extension).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
