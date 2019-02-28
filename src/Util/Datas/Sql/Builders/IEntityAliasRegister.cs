using System;
using System.Collections.Generic;

namespace Util.Datas.Sql.Builders {
    /// <summary>
    /// 实体别名注册器
    /// </summary>
    public interface IEntityAliasRegister {
        /// <summary>
        /// From子句设置的实体类型
        /// </summary>
        Type FromType { get; set; }
        /// <summary>
        /// 实体别名
        /// </summary>
        IDictionary<Type, string> Data { get; }
        /// <summary>
        /// 注册实体别名
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="alias">别名</param>
        void Register( Type type, string alias );
        /// <summary>
        /// 是否包含实体类型
        /// </summary>
        /// <param name="type">实体类型</param>
        bool Contains( Type type );
        /// <summary>
        /// 获取实体别名
        /// </summary>
        /// <param name="type">实体类型</param>
        string GetAlias( Type type );
        /// <summary>
        /// 复制实体别名注册器
        /// </summary>
        IEntityAliasRegister Clone();
    }
}
