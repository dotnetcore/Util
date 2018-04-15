using System.Threading.Tasks;

namespace Util.Applications.Operations {
    /// <summary>
    /// 删除操作
    /// </summary>
    public interface IDeleteAsync {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        Task DeleteAsync( string ids );
    }
}