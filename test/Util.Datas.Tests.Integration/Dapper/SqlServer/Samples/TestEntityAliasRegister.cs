using System;
using System.Collections.Generic;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Tests.Dapper.SqlServer.Samples {
    /// <summary>
    /// 实体别名注册器
    /// </summary>
    public class TestEntityAliasRegister : IEntityAliasRegister {
        /// <summary>
        /// 实体别名
        /// </summary>
        public Dictionary<Type, string> Data { get; }

        /// <summary>
        /// 注册实体别名
        /// </summary>
        /// <param name="entity">实体类型</param>
        /// <param name="alias">别名</param>
        public void Register( Type entity, string alias ) {
        }

        /// <summary>
        /// 是否包含实体
        /// </summary>
        /// <param name="entity">实体类型</param>
        public bool Contains( Type entity ) {
            return true;
        }

        /// <summary>
        /// 获取实体别名
        /// </summary>
        /// <param name="entity">实体类型</param>
        public string GetAlias( Type entity ) {
            return $"as_{entity.Name}";
        }
    }
}
