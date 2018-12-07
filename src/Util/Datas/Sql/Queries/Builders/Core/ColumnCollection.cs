using System;
using System.Linq;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries.Builders.Core {
    /// <summary>
    /// 列集合
    /// </summary>
    public class ColumnCollection {
        /// <summary>
        /// 初始化列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        /// <param name="tableAlias">表别名</param>
        /// <param name="table">表实体类型</param>
        /// <param name="raw">使用原始值</param>
        public ColumnCollection( string columns, string tableAlias = null, Type table = null, bool raw = false ) {
            Columns = columns;
            TableAlias = tableAlias;
            Table = table;
            Raw = raw;
        }

        /// <summary>
        /// 列集合
        /// </summary>
        public string Columns { get; }

        /// <summary>
        /// 表别名
        /// </summary>
        public string TableAlias { get; }

        /// <summary>
        /// 表实体类型
        /// </summary>
        public Type Table { get; }

        /// <summary>
        /// 使用原始值
        /// </summary>
        public bool Raw { get; }

        /// <summary>
        /// 获取列名列表
        /// </summary>
        /// <param name="dialect">Sql方言</param>
        /// <param name="register">实体别名注册器</param>
        public string ToSql( IDialect dialect,IEntityAliasRegister register ) {
            if ( Raw )
                return Columns;
            var columns = Columns.Split( ',' ).Select( column => new SqlItem( column,GetTableAlias( register ) ) ).ToList();
            return columns.Select( item => item.ToSql( dialect ) ).Join();
        }

        /// <summary>
        /// 获取表别名
        /// </summary>
        private string GetTableAlias( IEntityAliasRegister register ) {
            if ( register.Contains( Table ) )
                return register.GetAlias( Table );
            return TableAlias;
        }
    }
}
