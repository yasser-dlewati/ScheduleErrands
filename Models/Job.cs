namespace ScheduledErrands.Models
{
    public class Job
    {
        public int Id { get; set; }
        
        public JobType Type { get; set; }
        
        public DateTime ScheduledTime { get; set; }

        public string Name { get; set; }
    }
}