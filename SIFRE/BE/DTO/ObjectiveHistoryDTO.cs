namespace BE.DTO
{
    public class ObjectiveHistoryDTO
    {
        public int Id { get; set; }
        public Guid CollaboratorId {get; set;}
        public string Collaborator {get; set;}
        public int ObjectiveId { get; set; }
        public string Objective { get; set; }
        public string Progress { get; set; }
        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}