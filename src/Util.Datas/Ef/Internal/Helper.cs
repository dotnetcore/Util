using System;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Util.Domains;

namespace Util.Datas.Ef.Internal {
    /// <summary>
    /// 工具操作
    /// </summary>
    internal static class Helper {
        /// <summary>
        /// 初始化版本号
        /// </summary>
        public static void InitVersion( EntityEntry entry ) {
            var entity = entry.Entity as IAggregateRoot;
            if( entity == null )
                return;
            entity.Version = Encoding.UTF8.GetBytes( Guid.NewGuid().ToString() );
        }
    }
}
