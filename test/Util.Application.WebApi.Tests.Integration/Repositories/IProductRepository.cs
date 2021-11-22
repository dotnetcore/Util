using Util.Applications.Models;
using Util.Domain.Repositories;

namespace Util.Applications.Repositories {
    /// <summary>
    /// 产品仓储
    /// </summary>
    public interface IProductRepository : IRepository<Product> {
        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="product">产品</param>
        public void UpdateProduct( Product product );
    }
}