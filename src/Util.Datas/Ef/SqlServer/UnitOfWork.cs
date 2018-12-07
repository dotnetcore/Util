using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.Core;
using Util.Datas.UnitOfWorks;

namespace Util.Datas.Ef.SqlServer {
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public abstract class UnitOfWork : UnitOfWorkBase {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        /// <param name="options">配置</param>
        /// <param name="manager">工作单元服务</param>
        protected UnitOfWork( DbContextOptions options, IUnitOfWorkManager manager )
            : base( options, manager ) {
        }

        /// <summary>
        /// 获取映射接口类型
        /// </summary>
        protected override Type GetMapType() {
            return typeof( IMap );
        }

        /// <summary>
        /// 获取映射实例列表
        /// </summary>
        /// <param name="assembly">程序集</param>
        protected override IEnumerable<Util.Datas.Ef.Core.IMap> GetMapInstances( Assembly assembly ) {
            return Util.Helpers.Reflection.GetInstancesByInterface<IMap>( assembly );
        }
    }
}
