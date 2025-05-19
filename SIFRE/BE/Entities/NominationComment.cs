namespace BE.Entities
{
    public class NominationComment
    {
        public int Id { get; set; }
        public int NominationId { get; set; }
        public string Comment { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}