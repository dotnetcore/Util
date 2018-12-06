using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Util.Datas.Ef.Core;
using Util.Datas.Ef.Internal;
using Util.Datas.UnitOfWorks;

namespace Util.Datas.Ef.PgSql {
    /// <summary>
    /// PgSql工作单元
    /// </summary>
    public abstract class UnitOfWork : UnitOfWorkBase {
        /// <summary>
        /// 初始化PgSql工作单元
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

        /// <summary>
        /// 拦截添加操作
        /// </summary>
        protected override void InterceptAddedOperation( EntityEntry entry ) {
            base.InterceptAddedOperation( entry );
            Helper.InitVersion( entry );
        }

        /// <summary>
        /// 拦截修改操作
        /// </summary>
        protected override void InterceptModifiedOperation( EntityEntry entry ) {
            base.InterceptModifiedOperation( entry );
            Helper.InitVersion( entry );
        }
    }
}
