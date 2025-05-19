namespace BE.DTO
{
    public class ObjectiveDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ResponsibleUserName { get; set; }
        public Guid AssignedUserId { get; set; }
        public string AssignedUserName { get; set; }
        public string StatusName { get; set; }
        public string PriorityName { get; set; }
        public string CategoryName { get; set; }
        public int Progress { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int PointsAssigned { get; set; }
        public string RewardPolicyName { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedByName { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}