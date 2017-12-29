using Microsoft.EntityFrameworkCore;
using Util.Datas.Tests.PgSql.Configs;
using Util.Datas.UnitOfWorks;

namespace Util.Datas.Tests.Samples.Datas.PgSql.UnitOfWorks {
    /// <summary>
    /// PgSql工作单元
    /// </summary>
    public class PgSqlUnitOfWork : Util.Datas.Ef.PgSql.UnitOfWork, IPgSqlUnitOfWork {
        /// <summary>
        /// 初始化PgSql工作单元
        /// </summary>
        public PgSqlUnitOfWork( IUnitOfWorkManager unitOfWorkManager) : base( new DbContextOptionsBuilder().UseNpgsql( AppConfig.Connection ).Options, unitOfWorkManager ) {
        }
    }
}