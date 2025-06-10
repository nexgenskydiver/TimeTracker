namespace TimeTracker.Core.ViewModels
{
    public class TimeEntryViewModel
    {
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Duration { get; set; } = "";
        public string Notes { get; set; } = "";
        public string Tags { get; set; } = "";
    }
}
