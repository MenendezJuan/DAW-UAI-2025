namespace BE.Entities
{
    public class ObjectiveHistory
    {
        public int Id { get; set; }
        public int ObjectiveId { get; set; }
        public int StatusId { get; set; }
        public int Progress { get; set; }
        public Guid ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}