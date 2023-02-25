using System.Threading.Tasks;

namespace Util.Data.Metadata {
    /// <summary>
    /// 数据库元数据服务
    /// </summary>
    public interface IMetadataService {
        /// <summary>
        /// 获取数据库信息
        /// </summary>
        Task<DatabaseInfo> GetDatabaseInfoAsync();
    }
}
