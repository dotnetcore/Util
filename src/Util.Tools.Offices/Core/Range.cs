using System.Collections.Generic;

namespace Util.Tools.Offices.Core {
    /// <summary>
    /// 区
    /// </summary>
    public class Range {
        /// <summary>
        /// 初始化区
        /// </summary>
        /// <param name="startIndex">起始索引</param>
        public Range( int startIndex = 0 ) {
            _rows = new List<Row>();
            _startIndex = startIndex;
        }

        /// <summary>
        /// 行集
        /// </summary>
        private readonly List<Row> _rows;
        /// <summary>
        /// 起始索引
        /// </summary>
        private readonly int _startIndex;

        /// <summary>
        /// 获取行
        /// </summary>
        /// <param name="index">索引</param>
        public Row this[int index] => _rows[index];

        /// <summary>
        /// 获取行
        /// </summary>
        /// <param name="index">外部索引</param>
        public Row GetRow( int index ) {
            var realIndex = index - _startIndex;
            if ( realIndex < 0 )
                return null;
            if ( realIndex > _rows.Count - 1 )
                return null;
            return _rows[realIndex];
        }

        /// <summary>
        /// 列数
        /// </summary>
        public int ColumnNumber => _rows.Count > 0 ? _rows[0].ColumnNumber : 0;

        /// <summary>
        /// 行数
        /// </summary>
        public int Count => _rows.Count;

        /// <summary>
        /// 获取行
        /// </summary>
        public List<Row> GetRows() {
            return _rows;
        }

        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="cells">单元格集合</param>
        public void AddRow( int rowIndex, IEnumerable<Cell> cells ) {
            if ( cells == null )
                return;
            var row = CreateRow( rowIndex );
            foreach ( var cell in cells )
                AddCell( row, cell, rowIndex );
        }

        /// <summary>
        /// 创建行
        /// </summary>
        private Row CreateRow( int index ) {
            var row = GetRow( index );
            if ( row != null )
                return row;
            row = new Row( index );
            _rows.Add( row );
            return row;
        }

        /// <summary>
        /// 添加单元格
        /// </summary>
        private void AddCell( Row row, Cell cell, int rowIndex ) {
            row.Add( cell );
            if ( cell.RowSpan <= 1 )
                return;
            for ( int i = 1; i < cell.RowSpan; i++ )
                AddPlaceholderCell( cell, rowIndex + i );
        }

        /// <summary>
        /// 为下方受rowspan影响的行添加占位单元格
        /// </summary>
        private void AddPlaceholderCell( Cell cell, int rowIndex ) {
            var row = CreateRow( rowIndex );
            row.Add( new NullCell { ColumnIndex = cell.ColumnIndex, ColumnSpan = cell.ColumnSpan } );
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear() {
            _rows.Clear();
        }
    }
}
