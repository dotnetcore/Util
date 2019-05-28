using System.IO;
using Util.Tools.Offices.Core;

namespace Util.Tools.Offices.Abstractions {
    /// <summary>
    /// Excel操作
    /// </summary>
    public interface IExcel {
        /// <summary>
        /// 创建工作薄
        /// </summary>
        IExcel CreateWorkbook();
        /// <summary>
        /// 创建工作表
        /// </summary>
        /// <param name="sheetName">工作表名称</param>
        IExcel CreateSheet( string sheetName = "" );
        /// <summary>
        /// 创建行
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        IExcel CreateRow( int rowIndex );
        /// <summary>
        /// 创建单元格
        /// </summary>
        /// <param name="cell">单元格</param>
        IExcel CreateCell( Cell cell );
        /// <summary>
        /// 写入流
        /// </summary>
        /// <param name="stream">流</param>
        IExcel Write( Stream stream );
        /// <summary>
        /// 设置日期格式
        /// </summary>
        /// <param name="format">日期格式，默认"yyyy-mm-dd"</param>
        IExcel DateFormat( string format = "yyyy-mm-dd" );
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="startRowIndex">起始行索引</param>
        /// <param name="endRowIndex">结束行索引</param>
        /// <param name="startColumnIndex">起始列索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        IExcel MergeCell( int startRowIndex, int endRowIndex, int startColumnIndex, int endColumnIndex );
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="cell">单元格</param>
        IExcel MergeCell( Cell cell );
        /// <summary>
        /// 设置表头样式
        /// </summary>
        /// <param name="table">表格</param>
        /// <param name="style">单元格样式</param>
        IExcel HeadStyle( Table table, CellStyle style );
        /// <summary>
        /// 设置正文样式
        /// </summary>
        /// <param name="table">表格</param>
        /// <param name="style">单元格样式</param>
        IExcel BodyStyle( Table table, CellStyle style );
        /// <summary>
        /// 设置页脚样式
        /// </summary>
        /// <param name="table">表格</param>
        /// <param name="style">单元格样式</param>
        IExcel FootStyle( Table table, CellStyle style );
        /// <summary>
        /// 列宽
        /// </summary>
        /// <param name="columnIndex">列索引</param>
        /// <param name="width">列宽度，设置字符数</param>
        IExcel ColumnWidth( int columnIndex, int width );
    }
}
