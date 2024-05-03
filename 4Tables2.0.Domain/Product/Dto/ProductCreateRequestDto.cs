using _4Tables2._0.Domain.ProductDomain.Enum;

namespace _4Tables2._0.Domain.ProductDomain.Dto
{
    public record ProductCreateRequestDto(string name,
                                          string price,
                                          int? code,
                                          ProductCategory category
                                          );
}
