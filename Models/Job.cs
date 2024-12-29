namespace ScheduledErrands.Models
{
    public class Job
    {
        public int Id { get; set; }

        public JobType Type { get; set; }
        
        public RecurrenceType RecurrenceType { get; set; }

        public int Frequency { get; set; }

        public TimeOnly? SpecificTime { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}