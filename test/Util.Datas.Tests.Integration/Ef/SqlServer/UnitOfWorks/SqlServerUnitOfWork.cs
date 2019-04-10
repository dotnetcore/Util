using Microsoft.EntityFrameworkCore;
using Util.Aspects;
using Util.Datas.Tests.Commons.Datas.SqlServer.Configs;
using Util.Datas.UnitOfWorks;

namespace Util.Datas.Tests.Ef.SqlServer.UnitOfWorks {
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    [Ignore]
    public class SqlServerUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, ISqlServerUnitOfWork {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        public SqlServerUnitOfWork() : base( new DbContextOptionsBuilder().UseSqlServer( AppConfig.Connection ).Options ) {
        }
    }

    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class SqlServerUnitOfWork2 : Util.Datas.Ef.SqlServer.UnitOfWork, ISqlServerUnitOfWork {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="options">配置项</param>
        public SqlServerUnitOfWork2( DbContextOptions options ) : base( options ) {
        }
    }
}