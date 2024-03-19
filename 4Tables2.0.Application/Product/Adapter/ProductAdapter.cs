using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Tables2._0.Application.ProductApplication.Adapter
{
    public static class ProductAdapter
    {
        public static Product ToEntity(ProductCreateRequestDto dto)
        {
            decimal.TryParse(dto.price.Replace(',', '.'), out decimal price);

            return new Product()
                       .AddName(dto.name.ToUpper())
                       .AddPrice(price)
                       .AddTotalRequests(0)
                       .AddCategory(dto.category);
        }
    }
}
