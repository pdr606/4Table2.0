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
                       .AddCode(dto.code)
                       .AddCategory(dto.category);
        }

        public static ProductResponseDto ToDto(Product entity)
        {
            return new ProductResponseDto(entity.Id,
                                          entity.Name,
                                          entity.Price.ToString("N2").Replace('.', ','),
                                          entity.TotalRequests,
                                          entity.Code,
                                          entity.Category);
        }

        public static IEnumerable<ProductResponseDto> ToDto(List<Product> products)
        {
            foreach (var product in products)
            {
                yield return ToDto(product);
            }
        }

        public static IEnumerable<ProductResponseDto> ToDto(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                yield return ToDto(product);
            }
        }
    }
}
