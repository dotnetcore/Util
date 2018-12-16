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
            Order = order.SafeString();
            Desc = desc;
            Entity = entity;
            Raw = raw;
            if ( raw )
                return;
            if( Order.ToLower().EndsWith( "desc" ) ) {
                Desc = true;
                Order = Order.Remove( Order.Length - 4, 4 ).Trim();
            }
            var item = new NameItem( Order );
            Column = item.Name;
            Prefix = item.Prefix;
        }

        /// <summary>
        /// 排序列
        /// </summary>
        public string Order { get; }

        /// <summary>
        /// 排序列,不带前缀
        /// </summary>
        public string Column { get; }

        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; }

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
                return Order;
            var name = new NameItem( Order );
            var tableAlias = register.GetAlias( Entity );
            return $"{name.ToSql( dialect, tableAlias )} {( Desc ? "Desc" : null )}".TrimEnd();
        }
    }
}
