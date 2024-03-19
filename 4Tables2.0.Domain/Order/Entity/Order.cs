using _4Tables2._0.Domain.Base.Entity;
using _4Tables2._0.Domain.CostumeOrder.Entity;

namespace _4Tables2._0.Domain.OrderDomain.Entity
{
    public class Order : BaseEntity
    {
        public long Id { get; private set; }
        public decimal Total{ get; private set; } = 0;
        public List<CustomerOrder> CustomerOrdes { get; private set; } = new List<CustomerOrder>();

        public Order() { }

        #region builderMethods

        public Order AddId(long id)
        {
            Id = id; return this;
        }

        public Order AddTotal(decimal total) 
        {
            Total = total; return this;        
        }

        public Order AddCostumerOrders(List<CustomerOrder> orders)
        {
            CustomerOrdes.AddRange(orders); return this;
        }

        #endregion
    }
}
