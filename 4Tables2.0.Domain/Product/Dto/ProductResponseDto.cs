using _4Tables2._0.Domain.ProductDomain.Enum;

namespace _4Tables2._0.Domain.ProductDomain.Dto
{
    public record ProductResponseDto(long id,
                                     string name,
                                     string price,
                                     int totalRequests,
                                     ProductCategory Category);
}
