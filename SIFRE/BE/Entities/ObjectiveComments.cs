using BE.Base;

namespace BE.Entities
{
    public class ObjectiveComment : BaseEntity
    {
        public int ObjectiveId { get; set; }
        public string Comment { get; set; }
    }
}