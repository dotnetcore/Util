using System;
using Util.Datas.Sql.Builders.Extensions;

namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// 列
    /// </summary>
    public class ColumnItem {
        /// <summary>
        /// 初始化列
        /// </summary>
        /// <param name="name">列名</param>
        /// <param name="tableAlias">表别名</param>
        /// <param name="columnAlias">列别名</param>
        /// <param name="tableType">表实体类型</param>
        /// <param name="raw">使用原始值</param>
        /// <param name="isAggregation">是否聚合函数</param>
        public ColumnItem( string name, string tableAlias = null, string columnAlias = null, Type tableType = null, bool raw = false, bool isAggregation = false ) {
            Name = name;
            TableAlias = tableAlias;
            ColumnAlias = columnAlias;
            TableType = tableType;
            Raw = raw;
            IsAggregation = isAggregation;
        }

        /// <summary>
        /// 列名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 表别名
        /// </summary>
        public string TableAlias { get; set; }
        /// <summary>
        /// 列别名
        /// </summary>
        public string ColumnAlias { get; set; }
        /// <summary>
        /// 使用原始值
        /// </summary>
        public bool Raw { get; }
        /// <summary>
        /// 表实体类型
        /// </summary>
        public Type TableType { get; }
        /// <summary>
        /// 是否聚合函数
        /// </summary>
        public bool IsAggregation { get; }

        /// <summary>
        /// 获取列名列表
        /// </summary>
        /// <param name="dialect">Sql方言</param>
        /// <param name="register">实体别名注册器</param>
        public string ToSql( IDialect dialect, IEntityAliasRegister register ) {
            if ( Raw || IsAggregation )
                return dialect.GetColumn( Name,dialect.GetSafeName( ColumnAlias ) );
            var result = new SqlItem( Name, GetTableAlias( register ), ColumnAlias, isResolve: false );
            return result.ToSql( dialect );
        }

        /// <summary>
        /// 获取表别名
        /// </summary>
        private string GetTableAlias( IEntityAliasRegister register ) {
            if( register != null && register.Contains( TableType ) )
                return register.GetAlias( TableType );
            return TableAlias;
        }

        /// <summary>
        /// 复制
        /// </summary>
        public ColumnItem Clone() {
            return new ColumnItem( Name,TableAlias,ColumnAlias,TableType,Raw,IsAggregation );
        }
    }
}
