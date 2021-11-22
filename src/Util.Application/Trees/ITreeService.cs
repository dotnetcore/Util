using System.Threading.Tasks;
using Util.Data.Trees;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public interface ITreeService<TDto, in TQuery> : IQueryService<TDto, TQuery>
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">标识列表</param>
        Task EnableAsync( string ids );
        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="ids">标识列表</param>
        Task DisableAsync( string ids );
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的标识列表，范例："1,2"</param>
        Task DeleteAsync( string ids );
    }
}