using Microsoft.EntityFrameworkCore;
using Util.Datas.Tests.SqlServer.Configs;
using Util.Datas.UnitOfWorks;

namespace Util.Datas.Tests.Samples.Datas.SqlServer.UnitOfWorks {
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class SqlServerUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, ISqlServerUnitOfWork {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        public SqlServerUnitOfWork(IUnitOfWorkManager unitOfWorkManager) : base( new DbContextOptionsBuilder().UseSqlServer( AppConfig.Connection ).Options, unitOfWorkManager ) {
        }
    }

    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class SqlServerUnitOfWork2 : Util.Datas.Ef.SqlServer.UnitOfWork, ISqlServerUnitOfWork {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        public SqlServerUnitOfWork2( DbContextOptions options, IUnitOfWorkManager unitOfWorkManager ) : base( options, unitOfWorkManager ) {
        }
    }
}