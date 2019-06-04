using System;
using System.Collections.Generic;

namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// 实体别名注册器
    /// </summary>
    public class EntityAliasRegister : IEntityAliasRegister {
        /// <summary>
        /// 初始化实体别名注册器
        /// </summary>
        /// <param name="data">实体别名列表</param>
        public EntityAliasRegister( IDictionary<Type, string> data = null ) {
            Data = data ?? new Dictionary<Type, string>();
        }

        /// <summary>
        /// From子句设置的实体类型
        /// </summary>
        public Type FromType { get; set; }

        /// <summary>
        /// 实体别名列表
        /// </summary>
        public IDictionary<Type, string> Data { get; }

        /// <summary>
        /// 注册实体别名
        /// </summary>
        /// <param name="entity">实体类型</param>
        /// <param name="alias">别名</param>
        public void Register( Type entity, string alias ) {
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

        /// <summary>
        /// 复制实体别名注册器
        /// </summary>
        public IEntityAliasRegister Clone() {
            return new EntityAliasRegister( new Dictionary<Type, string>( Data ) );
        }
    }
}
