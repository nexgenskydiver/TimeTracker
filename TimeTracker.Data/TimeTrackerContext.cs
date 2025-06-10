using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Core.Models;

public class TimeTrackerContext : DbContext
{
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public TimeTrackerContext(DbContextOptions<TimeTrackerContext> opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TimeEntry>()
            .HasMany(te => te.Tags)
            .WithMany(t => t.TimeEntries)
            .UsingEntity(j => j.ToTable("EntryTag"));

        base.OnModelCreating(modelBuilder);
    }
}
