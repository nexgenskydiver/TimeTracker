// File: TimeTracker.Data/Repositories/TimeEntryRepository.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Core.Interfaces;
using TimeTracker.Core.Models;

namespace TimeTracker.Data.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private readonly IDbContextFactory<TimeTrackerContext> _factory;
        private readonly ITagRepository _tagRepo;

        public TimeEntryRepository(
            IDbContextFactory<TimeTrackerContext> factory,
            ITagRepository tagRepo)
        {
            _factory = factory;
            _tagRepo = tagRepo;
        }

        public async Task AddAsync(TimeEntry entry)
        {
            await using var ctx = _factory.CreateDbContext();
            ctx.TimeEntries.Add(entry);
            await ctx.SaveChangesAsync();
        }

        public async Task<TimeEntry?> GetInProgressAsync()
        {
            await using var ctx = _factory.CreateDbContext();
            return await ctx.TimeEntries
                            .Include(te => te.Tags)
                            .FirstOrDefaultAsync(te => te.EndTime == null);
        }

        public async Task EndAsync(
            int entryId,
            DateTimeOffset endTime,
            string notes,
            IEnumerable<string> tagNames)
        {
            await using var ctx = _factory.CreateDbContext();
            var entry = await ctx.TimeEntries
                                 .Include(te => te.Tags)
                                 .FirstAsync(te => te.TimeEntryId == entryId);

            entry.EndTime = endTime;
            entry.Notes = notes;

            foreach (var name in tagNames)
            {
                // Try find existing tag in this DB-context
                var tag = await ctx.Tags.FirstOrDefaultAsync(t => t.Name == name)
                          ?? new Tag { Name = name };

                if (tag.TagId == 0)
                    ctx.Tags.Add(tag);

                if (!entry.Tags.Any(t => t.TagId == tag.TagId))
                    entry.Tags.Add(tag);
            }

            await ctx.SaveChangesAsync();
        }

        public async Task<List<TimeEntry>> ListAllAsync()
        {
            await using var ctx = _factory.CreateDbContext();
            return await ctx.TimeEntries
                            .Include(te => te.Tags)
                            .OrderByDescending(te => te.StartTime)
                            .ToListAsync();
        }
    }
}
