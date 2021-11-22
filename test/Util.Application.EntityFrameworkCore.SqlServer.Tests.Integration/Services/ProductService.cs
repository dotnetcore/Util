using System;
using Util.Applications.Dtos;
using Util.Applications.Models;
using Util.Applications.Queries;
using Util.Applications.Repositories;
using Util.Applications.UnitOfWorks;

namespace Util.Applications.Services {
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
        public ProductService( IServiceProvider serviceProvider,ISqlServerUnitOfWork unitOfWork, IProductRepository repository ) : base( serviceProvider,unitOfWork, repository ) {
        }
    }
}