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
        /// <param name="dialect">Sql方言</param>
        /// <param name="entityAliasRegister">实体别名注册器</param>
        /// <param name="matedata">实体元数据解析器</param>
        /// <param name="parameterManager">参数管理器</param>
        /// <param name="clause">Sql子句访问器</param>
        public SqlContext( IDialect dialect, IEntityAliasRegister entityAliasRegister, IEntityMatedata matedata, IParameterManager parameterManager, IClauseAccessor clause ) {
            EntityAliasRegister = entityAliasRegister ?? new EntityAliasRegister();
            Matedata = matedata ?? new DefaultEntityMatedata();
            Dialect = dialect;
            ParameterManager = parameterManager;
            ClauseAccessor = clause ?? throw new ArgumentNullException( nameof( clause ) );
        }

        /// <summary>
        /// Sql方言
        /// </summary>
        public IDialect Dialect { get; }

        /// <summary>
        /// 实体别名注册器
        /// </summary>
        public IEntityAliasRegister EntityAliasRegister { get; }

        /// <summary>
        /// 实体元数据解析器
        /// </summary>
        public IEntityMatedata Matedata { get; }

        /// <summary>
        /// 参数管理器
        /// </summary>
        public IParameterManager ParameterManager { get; }

        /// <summary>
        /// Sql子句访问器
        /// </summary>
        public IClauseAccessor ClauseAccessor { get; }
    }
}
