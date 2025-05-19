using BE.Base;

namespace BE.Entities
{
    public class RewardPolicy : BaseEntity
    {
        public string PolicyName { get; set; }
        public string Description { get; set; }
        public decimal ConversionRate { get; set; }
        public decimal AccumulationLimit { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public bool IsActive { get; set; }
        public int? CategoryId { get; set; }
    }
}