using Util.Datas.Tests.Commons.Domains.Models;
using Util.Domains.Repositories;

namespace Util.Datas.Tests.Commons.Domains.Repositories {
    /// <summary>
    /// 商品仓储
    /// </summary>
    public interface IProductRepository : ICompactRepository<Product, int> {
        /// <summary>
        /// 通过编号获取商品 - 内部采用FirstOrDefault方法获取
        /// </summary>
        /// <param name="id">商品编号</param>
        Product GetById( int id );
    }
}
