using System;
using Util.Datas.Sql.Matedatas;

namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// Sql执行上下文
    /// </summary>
    public class SqlContext {
        /// <summary>
        /// 初始化Sql执行上下文
        /// </summary>
        /// <param name="entityAliasRegister">实体别名注册器</param>
        /// <param name="whereClause">实体别名注册器</param>
        /// <param name="matedata">实体元数据解析器</param>
        public SqlContext( IEntityAliasRegister entityAliasRegister, IWhereClause whereClause, IEntityMatedata matedata ) {
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
