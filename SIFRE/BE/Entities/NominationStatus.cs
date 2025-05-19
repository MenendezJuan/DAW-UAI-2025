using BE.Base;

namespace BE.Entities
{
    public class NominationStatus : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}