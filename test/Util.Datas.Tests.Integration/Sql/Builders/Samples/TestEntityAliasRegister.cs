using System;
using System.Collections.Generic;
using Util.Datas.Sql.Builders;
using Util.Datas.Sql.Builders.Core;

namespace Util.Datas.Tests.Sql.Builders.Samples {
    /// <summary>
    /// 实体别名注册器
    /// </summary>
    public class TestEntityAliasRegister : IEntityAliasRegister {
        /// <summary>
        /// From子句设置的实体类型
        /// </summary>
        public Type FromType { get; set; }

        /// <summary>
        /// 实体别名
        /// </summary>
        public IDictionary<Type, string> Data { get; }

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

        /// <summary>
        /// 复制实体别名注册器
        /// </summary>
        public IEntityAliasRegister Clone() {
            return new EntityAliasRegister( Data );
        }
    }
}
