using Util.Datas.Ef.Core;
using Util.Datas.Tests.Commons.Datas.Pos;
using Util.Datas.Tests.Ef.SqlServer.UnitOfWorks;

namespace Util.Datas.Tests.Ef.SqlServer.Stores {
    /// <summary>
    /// 商品持久化存储
    /// </summary>
    public class ProductPoStore : StoreBase<ProductPo, int>, IProductPoStore {
        /// <summary>
        /// 初始化商品持久化存储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ProductPoStore( ISqlServerUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
