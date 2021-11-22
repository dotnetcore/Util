using System;
using Microsoft.EntityFrameworkCore;
using Util.Sessions;

namespace Util.Data.EntityFrameworkCore.UnitOfWorks {
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class SqlServerUnitOfWork : SqlServerUnitOfWorkBase, ISqlServerUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">配置项</param>
        public SqlServerUnitOfWork( IServiceProvider serviceProvider ,DbContextOptions<SqlServerUnitOfWork> options) : base( serviceProvider, options ) {
        }

        /// <summary>
        /// 设置用户会话
        /// </summary>
        public void SetSession( ISession session ) {
            Session = session;
        }
    }
}