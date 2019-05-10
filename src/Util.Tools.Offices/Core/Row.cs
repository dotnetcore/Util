using System.Collections.Generic;
using System.Linq;

namespace Util.Tools.Offices.Core {
    /// <summary>
    /// 行
    /// </summary>
    public class Row {
        /// <summary>
        /// 初始化行
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        public Row( int rowIndex ) {
            Cells = new List<Cell>();
            RowIndex = rowIndex;
            _indexManager = new IndexManager();
        }

        /// <summary>
        /// 索引管理器
        /// </summary>
        private readonly IndexManager _indexManager;

        /// <summary>
        /// 单元格列表
        /// </summary>
        public List<Cell> Cells { get; set; }

        /// <summary>
        /// 获取单元格
        /// </summary>
        /// <param name="index">索引</param>
        public Cell this[ int index ] => Cells[index];

        /// <summary>
        /// 列数
        /// </summary>
        public int ColumnNumber {
            get { return Cells.Sum( t => t.ColumnSpan ); }
        }

        /// <summary>
        /// 行索引
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// 添加单元格
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="columnSpan">列跨度</param>
        /// <param name="rowSpan">行跨度</param>
        public void Add( object value,int columnSpan = 1,int rowSpan = 1 ) {
            Add( new Cell( value, columnSpan ,rowSpan) );
        }

        /// <summary>
        /// 添加单元格
        /// </summary>
        /// <param name="cell">单元格</param>
        public void Add( Cell cell ) {
            if ( cell == null )
                return;
            cell.Row = this;
            SetColumnIndex( cell );
            Cells.Add( cell );
        }

        /// <summary>
        /// 设置列索引
        /// </summary>
        private void SetColumnIndex( Cell cell ) {
            if ( cell.ColumnIndex > 0 ) {
                _indexManager.AddIndex( cell.ColumnIndex,cell.ColumnSpan );
                return;
            }
            cell.ColumnIndex = _indexManager.GetIndex( cell.ColumnSpan );
        }
    }
}
