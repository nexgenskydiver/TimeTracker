// TagRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Core.Interfaces;
using TimeTracker.Core.Models;

namespace TimeTracker.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly TimeTrackerContext _ctx;
        public TagRepository(TimeTrackerContext ctx) => _ctx = ctx;

        public Task<Tag?> GetByNameAsync(string name)
            => _ctx.Tags.FirstOrDefaultAsync(t => t.Name == name);

        public async Task<Tag> CreateAsync(Tag tag)
        {
            _ctx.Tags.Add(tag);
            await _ctx.SaveChangesAsync();
            return tag;
        }

        public Task<List<Tag>> ListAllAsync()
            => _ctx.Tags.ToListAsync();
    }
}
