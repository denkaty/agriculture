using Agriculture.Shared.Domain.Abstractions;

namespace Agriculture.Shared.Domain.Models.Base
{
    public class Entity : IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
