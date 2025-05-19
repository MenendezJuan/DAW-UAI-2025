using BE.Base;

namespace BE.Entities
{
    public class Nomination : BaseEntity
    {
        public Guid NominatorUserId { get; set; }
        public Guid NomineeUserId { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public string? Comments { get; set; }
    }
}