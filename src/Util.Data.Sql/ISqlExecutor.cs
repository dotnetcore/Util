using System.Threading.Tasks;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql执行器
    /// </summary>
    public interface ISqlExecutor : ISqlQuery, ISqlOperation {
        /// <summary>
        /// 执行Sql增删改操作
        /// </summary>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<int> ExecuteAsync( int? timeout = null );
        /// <summary>
        /// 执行存储过程增删改操作
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<int> ExecuteProcedureAsync( string procedure, int? timeout = null );
    }
}
