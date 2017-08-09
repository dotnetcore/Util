using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.Core;
using System.Data.Common;

namespace Util.Datas.Ef.SqlServer {
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public abstract class UnitOfWork : UnitOfWorkBase {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        /// <param name="connection">连接字符串</param>
        protected UnitOfWork( string connection )
            : base( new DbContextOptionsBuilder().UseSqlServer( connection ).Options ) {
        }

        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        /// <param name="connection">连接</param>
        protected UnitOfWork( DbConnection connection )
            : base( new DbContextOptionsBuilder().UseSqlServer( connection ).Options ) {
        }

        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        /// <param name="options">配置</param>
        protected UnitOfWork( DbContextOptions options )
            : base( options ) {
        }

        /// <summary>
        /// 获取映射类型列表
        /// </summary>
        /// <param name="assembly">程序集</param>
        protected override IEnumerable<Util.Datas.Ef.Core.IMap> GetMapTypes( Assembly assembly ) {
            return Util.Helpers.Reflection.GetTypesByInterface<IMap>( assembly );
        }
    }
}
