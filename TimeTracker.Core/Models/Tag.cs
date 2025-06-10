﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Core.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public List<TimeEntry> TimeEntries { get; set; } = new();
    }
}
