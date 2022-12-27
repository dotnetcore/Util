using System;
using Util.Applications;
using Util.Tests.Dtos;
using Util.Tests.Models;
using Util.Tests.Queries;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;

namespace Util.Tests.Services {
    /// <summary>
    /// 产品服务
    /// </summary>
    public class ProductService : CrudServiceBase<Product,ProductDto,ProductQuery>, IProductService {
        /// <summary>
        /// 初始化产品服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        public ProductService( IServiceProvider serviceProvider, ITestUnitOfWork unitOfWork, IProductRepository repository ) : base( serviceProvider,unitOfWork, repository ) {
        }
    }
}