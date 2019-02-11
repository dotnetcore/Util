using System;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Sql.Matedatas;
using Util.Domains;

namespace Util.Datas.Sql.Builders.Filters {
    /// <summary>
    /// 逻辑删除过滤器
    /// </summary>
    public class IsDeletedFilter : ISqlFilter {
        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="context">Sql查询执行上下文</param>
        public void Filter( SqlContext context ) {
            foreach( var item in context.EntityAliasRegister.Data )
                Filter( context.Matedata, context.Where, item.Key, item.Value );
        }

        /// <summary>
        /// 过滤
        /// </summary>
        private void Filter( IEntityMatedata matedata, IWhereClause where, Type type, string alias ) {
            if( type == null )
                return;
            if( string.IsNullOrWhiteSpace( alias ) )
                return;
            if( typeof( IDelete ).IsAssignableFrom( type ) )
                where.Where( $"{alias}.{matedata.GetColumn( type, "IsDeleted" )}", false );
        }
    }
}
