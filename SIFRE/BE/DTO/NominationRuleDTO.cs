namespace BE.DTO
{
    public class NominationRuleDTO
    {
        public int Id { get; set; }
        public string RuleName { get; set; }
        public string RuleValue { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}