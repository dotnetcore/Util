using Util.Data.EntityFrameworkCore.Models;
using Util.Domain.Repositories;

namespace Util.Data.EntityFrameworkCore.Repositories {
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