﻿using Microsoft.EntityFrameworkCore;
using Util.Datas.Tests.Commons.Datas.PgSql.Configs;

namespace Util.Datas.Tests.Ef.PgSql.UnitOfWorks {
    /// <summary>
    /// PgSql工作单元
    /// </summary>
    public class PgSqlUnitOfWork : Util.Datas.Ef.PgSql.UnitOfWork, IPgSqlUnitOfWork {
        /// <summary>
        /// 初始化PgSql工作单元
        /// </summary>
        public PgSqlUnitOfWork() : base( new DbContextOptionsBuilder().UseNpgsql( AppConfig.Connection ).Options ) {
        }
    }
}