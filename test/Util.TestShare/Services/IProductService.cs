using Util.Applications;
using Util.Tests.Dtos;
using Util.Tests.Queries;

namespace Util.Tests.Services {
    /// <summary>
    /// 产品服务
    /// </summary>
    public interface IProductService : ICrudService<ProductDto,ProductQuery> {
    }
}