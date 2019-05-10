using System.IO;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Util.Helpers;
using Util.Tools.Offices.Abstractions;
using Util.Tools.Offices.Core;

namespace Util.Tools.Offices.Npoi {
    /// <summary>
    /// Npoi Excel操作
    /// </summary>
    public abstract class ExcelBase : IExcel {
        /// <summary>
        /// Excel工作薄
        /// </summary>
        private IWorkbook _workbook;
        /// <summary>
        /// Excel工作表
        /// </summary>
        private ISheet _sheet;
        /// <summary>
        /// 当前行
        /// </summary>
        private IRow _row;
        /// <summary>
        /// 当前单元格
        /// </summary>
        private ICell _cell;
        /// <summary>
        /// 日期格式
        /// </summary>
        private string _dateFormat;
        /// <summary>
        /// 表头样式
        /// </summary>
        private ICellStyle _headStyle;
        /// <summary>
        /// 正文样式
        /// </summary>
        private ICellStyle _bodyStyle;
        /// <summary>
        /// 页脚样式
        /// </summary>
        private ICellStyle _footStyle;
        /// <summary>
        /// 日期样式
        /// </summary>
        private ICellStyle _dateStyle;

        /// <summary>
        /// 初始化Npoi操作
        /// </summary>
        protected ExcelBase() {
            _dateFormat = "yyyy-mm-dd";
            CreateWorkbook().CreateSheet();
        }

        /// <summary>
        /// 创建工作薄
        /// </summary>
        public IExcel CreateWorkbook() {
            _workbook = GetWorkbook();
            return this;
        }

        /// <summary>
        /// 创建工作薄
        /// </summary>
        protected abstract IWorkbook GetWorkbook();

        /// <summary>
        /// 创建工作表
        /// </summary>
        /// <param name="sheetName">工作表名称</param>
        public IExcel CreateSheet( string sheetName = "" ) {
            _sheet = sheetName.IsEmpty() ? _workbook.CreateSheet() : _workbook.CreateSheet( sheetName );
            return this;
        }

        /// <summary>
        /// 创建行
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        public IExcel CreateRow( int rowIndex ) {
            _row = GetOrCreateRow( rowIndex );
            return this;
        }

        /// <summary>
        /// 获取行，如果不存在则创建
        /// </summary>
        private IRow GetOrCreateRow( int rowIndex ) {
            return _sheet.GetRow( rowIndex ) ?? _sheet.CreateRow( rowIndex );
        }

        /// <summary>
        /// 创建单元格
        /// </summary>
        /// <param name="cell">单元格</param>
        public IExcel CreateCell( Cell cell ) {
            if ( cell.IsNull() )
                return this;
            _cell = GetOrCreateCell( _row, cell.ColumnIndex );
            SetCellValue( cell.Value );
            MergeCell( cell );
            return this;
        }

        /// <summary>
        /// 获取单元格，如果不存在则创建
        /// </summary>
        private ICell GetOrCreateCell( IRow row, int columnIndex ) {
            return row.GetCell( columnIndex ) ?? row.CreateCell( columnIndex );
        }

        /// <summary>
        /// 设置单元格的值
        /// </summary>
        private void SetCellValue( object value ) {
            if ( value == null )
                return;
            switch ( value.GetType().ToString() ) {
                case "System.String":
                    _cell.SetCellValue( value.ToString() );
                    break;
                case "System.DateTime":
                    _cell.SetCellValue( Convert.ToDate( value ) );
                    _cell.CellStyle = CreateDateStyle();
                    break;
                case "System.Boolean":
                    _cell.SetCellValue( Convert.ToBool( value ) );
                    break;
                case "System.Byte":
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                    _cell.SetCellValue( Convert.ToInt( value ) );
                    break;
                case "System.Double":
                case "System.Decimal":
                    _cell.SetCellValue( Convert.ToDouble( value ) );
                    break;
                default:
                    _cell.SetCellValue( "" );
                    break;
            }
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="startRowIndex">起始行索引</param>
        /// <param name="endRowIndex">结束行索引</param>
        /// <param name="startColumnIndex">起始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        public IExcel MergeCell( int startRowIndex, int endRowIndex, int startColumnIndex, int endColumnIndex ) {
            var region = new CellRangeAddress( startRowIndex, endRowIndex, startColumnIndex, endColumnIndex );
            _sheet.AddMergedRegion( region );
            return this;
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="cell">单元格</param>
        public IExcel MergeCell( Cell cell ) {
            if ( cell.NeedMerge )
                MergeCell( cell.RowIndex, cell.EndRowIndex, cell.ColumnIndex, cell.EndColumnIndex );
            return this;
        }

        /// <summary>
        /// 写入流
        /// </summary>
        /// <param name="stream">流</param>
        public IExcel Write( Stream stream ) {
            _workbook.Write( stream );
            return this;
        }

        /// <summary>
        /// 创建日期样式
        /// </summary>
        private ICellStyle CreateDateStyle() {
            if ( _dateStyle != null )
                return _dateStyle;
            _dateStyle = CellStyleResolver.Resolve( _workbook, CellStyle.Body() );
            var format = _workbook.CreateDataFormat();
            _dateStyle.DataFormat = format.GetFormat( _dateFormat );
            return _dateStyle;
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="startRowIndex">起始行索引</param>
        /// <param name="endRowIndex">结束行索引</param>
        /// <param name="startColumnIndex">起始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        /// <param name="style">单元格样式</param>
        protected IExcel Style( int startRowIndex, int endRowIndex, int startColumnIndex, int endColumnIndex, ICellStyle style ) {
            for ( var i = startRowIndex; i <= endRowIndex; i++ ) {
                var row = GetOrCreateRow( i );
                for( var j = startColumnIndex; j <= endColumnIndex; j++ )
                    GetOrCreateCell( row, j ).CellStyle = style;
            }
            return this;
        }

        /// <summary>
        /// 设置表头样式
        /// </summary>
        /// <param name="table">表格</param>
        /// <param name="style">单元格样式</param>
        public IExcel HeadStyle( Table table, CellStyle style ) {
            if( _headStyle == null )
                _headStyle = CellStyleResolver.Resolve( _workbook, style );
            Style( 0, table.HeadRowCount - 1, 0, table.ColumnNumber - 1, _headStyle );
            return this;
        }

        /// <summary>
        /// 设置正文样式
        /// </summary>
        /// <param name="table">表格</param>
        /// <param name="style">单元格样式</param>
        public IExcel BodyStyle( Table table, CellStyle style ) {
            if ( _bodyStyle == null )
                _bodyStyle = CellStyleResolver.Resolve( _workbook, style );
            Style( table.HeadRowCount, table.HeadRowCount + table.BodyRowCount - 1, 0, table.ColumnNumber - 1, _bodyStyle );
            return this;
        }

        /// <summary>
        /// 设置页脚样式
        /// </summary>
        /// <param name="table">表格</param>
        /// <param name="style">单元格样式</param>
        public IExcel FootStyle( Table table, CellStyle style ) {
            if ( _footStyle == null )
                _footStyle = CellStyleResolver.Resolve( _workbook, style );
            Style( table.HeadRowCount + table.BodyRowCount, table.Count - 1, 0, table.ColumnNumber - 1, _footStyle );
            return this;
        }

        /// <summary>
        /// 设置日期格式
        /// </summary>
        /// <param name="format">日期格式，默认"yyyy-mm-dd"</param>
        public IExcel DateFormat( string format = "yyyy-mm-dd" ) {
            _dateFormat = format;
            return this;
        }

        /// <summary>
        /// 列宽
        /// </summary>
        /// <param name="columnIndex">列索引</param>
        /// <param name="width">列宽度，设置字符数</param>
        public IExcel ColumnWidth( int columnIndex, int width ) {
            _sheet.SetColumnWidth( columnIndex,width * 256 );
            return this;
        }
    }
}
