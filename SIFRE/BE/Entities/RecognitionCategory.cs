using BE.Base;

namespace BE.Entities
{
    public class RecognitionCategory : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Points { get; set; }
    }
}