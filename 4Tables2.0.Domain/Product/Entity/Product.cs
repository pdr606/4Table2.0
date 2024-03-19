using _4Tables2._0.Domain.Base.Entity;
using _4Tables2._0.Domain.CostumeOrder.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;

namespace _4Tables2._0.Domain.ProductDomain.Entity
{
    public class Product : BaseEntity
    {
        public long Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public int TotalRequests{ get; private set; }
        public ProductCategory Category { get; private set; }
        public CustomerOrder CostumerOrder { get; private set; }

        public Product() { }

        #region builderMethods

        public Product AddId(long id)
        {
            Id = id; return this;
        }

        public Product AddName(string name)
        {
            Name = name; return this;
        }

        public Product AddPrice(decimal price)
        {
            Price = price; return this;
        }

        public Product AddTotalRequests(int totalRequests)
        {
            TotalRequests = totalRequests; return this;
        }

        public Product AddCategory(ProductCategory category)
        {
            Category = category; return this;
        }
        #endregion
    }
}
