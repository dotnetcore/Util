using System.Collections.Generic;
using System.Linq;

namespace Util.Tools.Offices.Core {
    /// <summary>
    /// 表格
    /// </summary>
    public class Table {
        /// <summary>
        /// 头部
        /// </summary>
        private readonly Range _header;

        /// <summary>
        /// 正文
        /// </summary>
        private Range _body;

        /// <summary>
        /// 底部
        /// </summary>
        private Range _footer;

        /// <summary>
        /// 当前行索引
        /// </summary>
        private int _rowIndex;

        /// <summary>
        /// 初始化表格
        /// </summary>
        public Table() {
            _header = new Range();
            _rowIndex = 0;
        }

        /// <summary>
        /// 总标题
        /// </summary>
        public string Title {
            get {
                if ( _header.Count == 0 )
                    return string.Empty;
                if ( _header[0].Cells.Count > 1 )
                    return string.Empty;
                return _header[0][0].Value.SafeString();
            }
        }

        /// <summary>
        /// 列数
        /// </summary>
        public int ColumnNumber => _body?.ColumnNumber ?? _header.ColumnNumber;

        /// <summary>
        /// 表头行数
        /// </summary>
        public int HeadRowCount => _header.Count;

        /// <summary>
        /// 正文行数
        /// </summary>
        public int BodyRowCount => _body?.Count ?? 0;

        /// <summary>
        /// 页脚行数
        /// </summary>
        public int FootRowCount => _footer?.Count ?? 0;

        /// <summary>
        /// 总行数
        /// </summary>
        public int Count => HeadRowCount + BodyRowCount + FootRowCount;

        /// <summary>
        /// 获取表头
        /// </summary>
        public List<Row> GetHeader() {
            return _header.GetRows();
        }

        /// <summary>
        /// 获取表格正文
        /// </summary>
        public List<Row> GetBody() {
            return _body == null ? new List<Row>() : _body.GetRows();
        }

        /// <summary>
        /// 获取页脚
        /// </summary>
        public List<Row> GetFooter() {
            return _footer == null ? new List<Row>() : _footer.GetRows();
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        /// <param name="titles">标题</param>
        public void AddHeadRow( params string[] titles ) {
            if ( titles == null )
                return;
            AddHeadRow( titles.Select( title => new Cell( title ) ).ToArray() );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        /// <param name="cells">表头</param>
        public void AddHeadRow( params Cell[] cells ) {
            if ( cells == null )
                return;
            AddRowToHeader( cells );
            ResetFirstColumnSpan();
        }

        /// <summary>
        /// 添加表头行
        /// </summary>
        private void AddRowToHeader( IEnumerable<Cell> cells ) {
            _header.AddRow(_rowIndex, cells );
            _rowIndex++;
        }

        /// <summary>
        /// 重置第一行的列跨度，第一行可能为总标题
        /// </summary>
        private void ResetFirstColumnSpan() {
            if ( _rowIndex < 2 )
                return;
            if ( _header.Count == 0 )
                return;
            if ( _header[0].ColumnNumber > 1 )
                return;
            if ( _header.Count > 1 ) {
                _header[0][0].ColumnSpan = _header[1].ColumnNumber;
                return;
            }
            if ( _body == null || _body.Count == 0 )
                return;
            _header[0][0].ColumnSpan = _body[0].ColumnNumber;
        }

        /// <summary>
        /// 添加正文
        /// </summary>
        /// <param name="cellValues">值</param>
        public void AddBodyRow( params object[] cellValues ) {
            if ( cellValues == null )
                return;
            AddBodyRow( cellValues.Select( t => new Cell( t ) ) );
        }

        /// <summary>
        /// 添加正文
        /// </summary>
        /// <param name="cells">单元格集合</param>
        public void AddBodyRow( IEnumerable<Cell> cells ) {
            if ( cells == null )
                return;
            GetBodyRange().AddRow( _rowIndex,cells );
            _rowIndex++;
            ResetFirstColumnSpan();
        }

        /// <summary>
        /// 获取正文区域
        /// </summary>
        private Range GetBodyRange() {
            if ( _body != null )
                return _body;
            _body = new Range( _rowIndex );
            return _body;
        }

        /// <summary>
        /// 添加页脚
        /// </summary>
        /// <param name="cellValues">值</param>
        public void AddFootRow( params string[] cellValues ) {
            if ( cellValues == null )
                return;
            AddFootRow( cellValues.Select( t => new Cell( t ) ).ToArray() );
        }

        /// <summary>
        /// 添加页脚
        /// </summary>
        /// <param name="cells">单元格集合</param>
        public void AddFootRow( params Cell[] cells ) {
            if ( cells == null )
                return;
            GetFootRange().AddRow( _rowIndex, cells );
            _rowIndex++;
        }

        /// <summary>
        /// 获取页脚区域
        /// </summary>
        private Range GetFootRange() {
            if ( _footer != null )
                return _footer;
            _footer = new Range( _rowIndex );
            return _footer;
        }

        /// <summary>
        /// 清空表头
        /// </summary>
        public void ClearHeader() {
            _header.Clear();
        }
    }
}
