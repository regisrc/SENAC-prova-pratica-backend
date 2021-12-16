namespace ProvaPratica.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; private set; }

        public bool Active { get; private set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            Active = true;
        }

        public void DesactivateData() => Active = false;
    }
}
