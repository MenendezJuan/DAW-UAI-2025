namespace BE.DTO
{
    public class NominationCommentDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}