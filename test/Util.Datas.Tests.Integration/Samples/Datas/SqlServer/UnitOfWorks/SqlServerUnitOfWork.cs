using Util.Datas.Tests.SqlServer.Confis;

namespace Util.Datas.Tests.Samples.Datas.SqlServer.UnitOfWorks {
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class SqlServerUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, ISqlServerUnitOfWork {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        public SqlServerUnitOfWork() : base( AppConfig.Connection ) {
        }
    }
}