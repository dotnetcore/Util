using System;
using Microsoft.EntityFrameworkCore;

namespace Util.Data.EntityFrameworkCore {
    /// <summary>
    /// MySql工作单元基类
    /// </summary>
    public abstract class MySqlUnitOfWorkBase : UnitOfWorkBase {
        /// <summary>
        /// 初始化MySql工作单元
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">配置</param>
        protected MySqlUnitOfWorkBase( IServiceProvider serviceProvider, DbContextOptions options )
            : base( serviceProvider, options ) {
        }
    }
}
