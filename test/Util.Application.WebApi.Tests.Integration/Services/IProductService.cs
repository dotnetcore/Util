using Util.Applications.Dtos;
using Util.Applications.Queries;

namespace Util.Applications.Services {
    /// <summary>
    /// 产品服务
    /// </summary>
    public interface IProductService : ICrudService<ProductDto,ProductQuery> {
    }
}