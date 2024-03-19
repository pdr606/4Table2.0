namespace _4Tables2._0.Domain.Base.Entity
{
    public class BaseEntity
    {
        public bool Available { get; private set; } = true;
        public DateTime Created_At { get; private set; } = DateTime.UtcNow.AddHours(-3);
        public DateTime Updated_At { get; private set; }

        public BaseEntity ActiveOrDesactive(bool available)
        {
            if (available) Available = true; else Available = false; return this;
        }

        public BaseEntity Update()
        {
            Updated_At = DateTime.UtcNow.AddHours(-3); return this;
        }
    }
}
