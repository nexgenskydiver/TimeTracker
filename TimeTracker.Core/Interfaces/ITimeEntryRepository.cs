using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTracker.Core.Models;

namespace TimeTracker.Core.Interfaces
{
    public interface ITimeEntryRepository
    {
        /// <summary>
        /// Create a new in-progress time entry (Start was clicked).
        /// </summary>
        Task AddAsync(TimeEntry entry);

        /// <summary>
        /// Fetch the one entry with no EndTime (if any).
        /// </summary>
        Task<TimeEntry?> GetInProgressAsync();

        /// <summary>
        /// Complete an entry: set its EndTime, Notes and attach any Tags.
        /// </summary>
        Task EndAsync(
            int entryId,
            DateTimeOffset endTime,
            string notes,
            IEnumerable<string> tagNames
        );

        /// <summary>
        /// (Optional) List all entries, or you can add filtering methods here.
        /// </summary>
        Task<List<TimeEntry>> ListAllAsync();
    }
}
