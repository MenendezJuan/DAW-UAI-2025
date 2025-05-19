using BE.Base;

namespace BE.Entities
{
    public class NominationRule : BaseEntity
    {
        public string? RuleName { get; set; }
        public string RuleValue { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}