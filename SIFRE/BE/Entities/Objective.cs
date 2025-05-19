using BE.Base;

namespace BE.Entities
{
    public class Objective : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ResponsibleUserId { get; set; }
        public Guid AssignedUserId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int CategoryId { get; set; }
        public int Progress { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int PointsAssigned { get; set; }
        public int RewardPolicyId { get; set; }
    }
}