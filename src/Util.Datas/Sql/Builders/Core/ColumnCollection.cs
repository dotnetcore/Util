using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// 列集合
    /// </summary>
    public class ColumnCollection {
        /// <summary>
        /// 列集合
        /// </summary>
        private readonly List<ColumnItem> _items;

        /// <summary>
        /// 初始化列集合
        /// </summary>
        public ColumnCollection( List<ColumnItem> items = null ) {
            _items = items ?? new List<ColumnItem>();
        }

        /// <summary>
        /// 获取列
        /// </summary>
        /// <param name="index">索引</param>
        public ColumnItem this[int index] => _items[index];

        /// <summary>
        /// 集合数量
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// 添加列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        /// <param name="tableAlias">表别名</param>
        public void AddColumns( string columns, string tableAlias = null ) {
            if( columns.IsEmpty() )
                return;
            var items = columns.Split( ',' ).Select( column => CreateItem( column, tableAlias ) ).ToList();
            items.ForEach( AddColumn );
        }

        /// <summary>
        /// 创建列
        /// </summary>
        private ColumnItem CreateItem( string column, string tableAlias ) {
            var item = new SqlItem( column, tableAlias );
            return new ColumnItem( item.Name, item.Prefix, item.Alias );
        }

        /// <summary>
        /// 添加列
        /// </summary>
        /// <param name="item">列</param>
        public void AddColumn( ColumnItem item ) {
            if( item == null )
                return;
            _items.Add( item );
        }

        /// <summary>
        /// 添加原始列
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="columnAlias">列别名</param>
        public void AddRawColumn( string sql, string columnAlias = null ) {
            if( sql.IsEmpty() )
                return;
            _items.Add( new ColumnItem( sql,columnAlias: columnAlias, raw: true ) );
        }

        /// <summary>
        /// 添加列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        /// <param name="tableType">表实体类型</param>
        /// <param name="columnAlias">列别名</param>
        public void AddColumns( string columns, Type tableType, string columnAlias = null ) {
            if( columns.IsEmpty() )
                return;
            var items = columns.Split( ',' ).Select( column => CreateItem( column, tableType, columnAlias ) ).ToList();
            items.ForEach( item => {
                RemoveColumn( item );
                AddColumn( item );
            } );
        }

        /// <summary>
        /// 创建列
        /// </summary>
        private ColumnItem CreateItem( string column, Type tableType, string columnAlias = null ) {
            var item = new SqlItem( column,alias: columnAlias );
            return new ColumnItem( item.Name, columnAlias:item.Alias,tableType: tableType );
        }

        /// <summary>
        /// 添加聚合列
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="columnAlias">列别名</param>
        public void AddAggregationColumn( string column, string columnAlias ) {
            if( column.IsEmpty() )
                return;
            _items.Add( new ColumnItem( column, columnAlias: columnAlias, isAggregation: true ) );
        }

        /// <summary>
        /// 移除列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        /// <param name="tableAlias">表别名</param>
        public void RemoveColumns( string columns, string tableAlias = null ) {
            if( columns.IsEmpty() )
                return;
            var items = columns.Split( ',' ).Select( column => CreateItem( column, tableAlias ) ).ToList();
            items.ForEach( RemoveColumn );
        }

        /// <summary>
        /// 移除列集合
        /// </summary>
        private void RemoveColumn( ColumnItem item ) {
            if( item == null )
                return;
            _items.RemoveAll( t => t.Name == item.Name && t.TableAlias == item.TableAlias && t.TableType == item.TableType );
        }

        /// <summary>
        /// 移除列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        /// <param name="tableType">表实体类型</param>
        public void RemoveColumns( string columns, Type tableType ) {
            if( columns.IsEmpty() )
                return;
            var items = columns.Split( ',' ).Select( column => CreateItem( column, tableType ) ).ToList();
            items.ForEach( RemoveColumn );
        }

        /// <summary>
        /// 复制
        /// </summary>
        public ColumnCollection Clone() {
            return new ColumnCollection(_items.Select( t => t.Clone() ).ToList() );
        }

        /// <summary>
        /// 获取列名列表
        /// </summary>
        /// <param name="dialect">Sql方言</param>
        /// <param name="register">实体别名注册器</param>
        public string ToSql( IDialect dialect, IEntityAliasRegister register ) {
            var result = new StringBuilder();
            foreach( var item in _items ) {
                result.Append( item.ToSql( dialect, register ) );
                if ( item.Raw == false )
                    result.Append( "," );
            }
            return result.ToString().TrimEnd( ',' );
        }
    }
}
