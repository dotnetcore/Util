using System;
using Util.Datas.Matedatas;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries.Builders.Core {
    /// <summary>
    /// Sql查询执行上下文
    /// </summary>
    public class SqlQueryContext {
        /// <summary>
        /// 初始化Sql查询执行上下文
        /// </summary>
        /// <param name="entityAliasRegister">实体别名注册器</param>
        /// <param name="whereClause">实体别名注册器</param>
        /// <param name="matedata">实体元数据解析器</param>
        public SqlQueryContext( IEntityAliasRegister entityAliasRegister, IWhereClause whereClause, IEntityMatedata matedata ) {
            EntityAliasRegister = entityAliasRegister ?? new EntityAliasRegister();
            Where = whereClause ?? throw new ArgumentNullException( nameof(whereClause) );
            Matedata = matedata;
        }

        /// <summary>
        /// 实体别名注册器
        /// </summary>
        public IEntityAliasRegister EntityAliasRegister { get; }

        /// <summary>
        /// Where子句
        /// </summary>
        public IWhereClause Where { get; }

        /// <summary>
        /// 实体元数据解析器
        /// </summary>
        public IEntityMatedata Matedata { get; }
    }
}
