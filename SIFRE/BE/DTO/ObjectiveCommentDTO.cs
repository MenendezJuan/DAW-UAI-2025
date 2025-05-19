namespace BE.DTO
{
    public class ObjectiveCommentDTO
    {
        public int Id { get; set; }
        public int ObjectiveId { get; set; }
        public string Comment { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedByName { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}