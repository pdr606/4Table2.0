using _4Tables2._0.Domain.Base.Entity;
using _4Tables2._0.Domain.OrderDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Entity;

namespace _4Tables2._0.Domain.CostumeOrder.Entity
{
    public class CustomerOrder : BaseEntity
    {
        public long Id { get; private set; }
        public int Quantity { get; private set; }
        public string? Observation { get; private set; } = string.Empty;
        public Product Product { get; private set; }
        public long ProductId { get; private set; }
        public Order Order { get; private set; }
        public long OrderId { get; private set; }

        public CustomerOrder() { }

        #region builderMethods

        public CustomerOrder AddId(long id)
        {
            Id = id; return this;
        }

        public CustomerOrder AddQuantity(int quantity)
        {
            Quantity = quantity; return this;
        }

        public CustomerOrder AddObservation(string observation)
        {
            Observation = observation; return this;
        }

        public CustomerOrder AddProduct(Product product)
        {
            Product = product; return this;
        }

        public CustomerOrder AddOrder(Order order)
        {
            Order = order; return this;
        }

        #endregion


    }
}
