using Util.Data.EntityFrameworkCore;
using Util.Tests.Models;
using Util.Tests.UnitOfWorks;

namespace Util.Tests.Repositories {
    /// <summary>
    /// 产品仓储
    /// </summary>
    public class ProductRepository : RepositoryBase<Product>,IProductRepository {
        /// <summary>
        /// 初始化产品仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ProductRepository( ITestUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="product">产品</param>
        public void UpdateProduct( Product product ) {
            UnitOfWork.Update( product );
        }
    }
}