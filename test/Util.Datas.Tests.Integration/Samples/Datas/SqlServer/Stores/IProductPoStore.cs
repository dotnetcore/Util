using Util.Datas.Persistence;
using Util.Datas.Tests.Samples.Datas.Pos;

namespace Util.Datas.Tests.Samples.Datas.SqlServer.Stores {
    /// <summary>
    /// 商品持久化存储
    /// </summary>
    public interface IProductPoStore : IPersistentStore<ProductPo, int> {
    }
}
