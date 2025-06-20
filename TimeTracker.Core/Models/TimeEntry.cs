﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Core.Models
{
    public  class TimeEntry
    {
        public int TimeEntryId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        // Never null at construction
        public string Notes { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = new();
    }
}
