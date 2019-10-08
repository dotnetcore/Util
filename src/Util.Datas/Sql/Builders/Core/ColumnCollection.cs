using System;
using System.Linq;

namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// 列集合
    /// </summary>
    public class ColumnCollection {
        /// <summary>
        /// 初始化列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        /// <param name="tableAlias">表别名</param>
        /// <param name="tableType">表实体类型</param>
        /// <param name="raw">使用原始值</param>
        /// <param name="isAggregation">是否聚合函数</param>
        public ColumnCollection( string columns, string tableAlias = null, Type tableType = null, bool raw = false, bool isAggregation = false ) {
            Columns = columns;
            TableAlias = tableAlias;
            TableType = tableType;
            Raw = raw;
            IsAggregation = isAggregation;
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
        public Type TableType { get; }
        /// <summary>
        /// 使用原始值
        /// </summary>
        public bool Raw { get; }
        /// <summary>
        /// 是否聚合函数
        /// </summary>
        public bool IsAggregation { get; }

        /// <summary>
        /// 获取列名列表
        /// </summary>
        /// <param name="dialect">Sql方言</param>
        /// <param name="register">实体别名注册器</param>
        public string ToSql( IDialect dialect,IEntityAliasRegister register ) {
            if ( Raw )
                return Columns;
            if( IsAggregation )
                return Columns;
            var columns = Columns.Split( ',' ).Select( column => new SqlItem( column,GetTableAlias( register ) ) ).ToList();
            return columns.Select( item => item.ToSql( dialect ) ).Join();
        }

        /// <summary>
        /// 获取表别名
        /// </summary>
        private string GetTableAlias( IEntityAliasRegister register ) {
            if ( register != null && register.Contains( TableType ) )
                return register.GetAlias( TableType );
            return TableAlias;
        }
    }
}
