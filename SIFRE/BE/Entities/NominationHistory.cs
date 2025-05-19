namespace BE.Entities
{
    public class NominationHistory
    {
        public int Id { get; set; }
        public int NominationId { get; set; }
        public int StatusId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}