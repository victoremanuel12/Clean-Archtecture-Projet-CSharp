namespace CleanArchMvc.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
