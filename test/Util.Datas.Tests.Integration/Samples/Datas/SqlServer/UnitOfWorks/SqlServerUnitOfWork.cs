using Util.Aspects;
using Util.Datas.Tests.SqlServer.Configs;
using Util.Datas.UnitOfWorks;

namespace Util.Datas.Tests.Samples.Datas.SqlServer.UnitOfWorks {
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    [Ignore]
    public class SqlServerUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, ISqlServerUnitOfWork {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        public SqlServerUnitOfWork(IUnitOfWorkManager unitOfWorkManager) : base( AppConfig.Connection, unitOfWorkManager ) {
        }
    }
}