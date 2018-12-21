using System;
using System.Collections.Generic;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries.Builders.Core {
    /// <summary>
    /// 实体别名注册器
    /// </summary>
    public class EntityAliasRegister : IEntityAliasRegister {
        /// <summary>
        /// 初始化实体别名注册器
        /// </summary>
        public EntityAliasRegister() {
            Data = new Dictionary<Type, string>();
        }

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
            if ( Data.ContainsKey( entity ) )
                Data.Remove( entity );
            Data[entity] = alias;
        }

        /// <summary>
        /// 是否包含实体
        /// </summary>
        /// <param name="entity">实体类型</param>
        public bool Contains( Type entity ) {
            if ( entity == null )
                return false;
            return Data.ContainsKey( entity );
        }

        /// <summary>
        /// 获取实体别名
        /// </summary>
        /// <param name="entity">实体类型</param>
        public string GetAlias( Type entity ) {
            if ( entity == null )
                return null;
            if ( Data.ContainsKey( entity ) )
                return Data[entity];
            return null;
        }
    }
}
