using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Core.Models;

namespace TimeTracker.Core.Interfaces
{
    public interface ITagRepository
    {
        /// <summary>
        /// Find a tag by its name, or return null if none exists.
        /// </summary>
        Task<Tag?> GetByNameAsync(string name);

        /// <summary>
        /// Create a new tag and persist it.
        /// </summary>
        Task<Tag> CreateAsync(Tag tag);

        /// <summary>
        /// List all tags in the database.
        /// </summary>
        Task<List<Tag>> ListAllAsync();
    }
}
