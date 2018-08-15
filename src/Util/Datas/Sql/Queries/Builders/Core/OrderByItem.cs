using System;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries.Builders.Core {
    /// <summary>
    /// 排序项
    /// </summary>
    public class OrderByItem {
        /// <summary>
        /// 初始化排序项
        /// </summary>
        /// <param name="order">排序列</param>
        /// <param name="desc">是否倒排</param>
        /// <param name="entity">实体类型</param>
        /// <param name="raw">使用原始值</param>
        public OrderByItem( string order,bool desc = false,Type entity = null,bool raw = false ) {
            Column = order.SafeString();
            Desc = desc;
            Entity = entity;
            Raw = raw;
            if ( raw )
                return;
            if( Column.ToLower().EndsWith( "desc" ) ) {
                Desc = true;
                Column = Column.Remove( Column.Length - 4, 4 );
            }
        }

        /// <summary>
        /// 排序列
        /// </summary>
        public string Column { get; }

        /// <summary>
        /// 是否倒排
        /// </summary>
        public bool Desc { get; }

        /// <summary>
        /// 实体类型
        /// </summary>
        public Type Entity { get; }

        /// <summary>
        /// 使用原始值
        /// </summary>
        public bool Raw { get; }

        /// <summary>
        /// 获取Sql
        /// </summary>
        /// <param name="dialect">Sql方言</param>
        /// <param name="register">实体别名注册器</param>
        public string ToSql( IDialect dialect, IEntityAliasRegister register ) {
            if ( Raw )
                return Column;
            var name = new NameItem( Column );
            var tableAlias = register.GetAlias( Entity );
            return $"{name.ToSql( dialect, tableAlias )} {( Desc ? "Desc" : null )}".TrimEnd();
        }
    }
}
