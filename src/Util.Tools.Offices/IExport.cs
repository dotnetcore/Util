using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Util.Tools.Offices {
    /// <summary>
    /// 文件导出器
    /// </summary>
    public interface IExport {
        /// <summary>
        /// 设置日期格式
        /// </summary>
        /// <param name="format">日期格式，默认"yyyy-mm-dd"</param>
        IExport DateFormat( string format = "yyyy-mm-dd" );
        /// <summary>
        /// 列宽
        /// </summary>
        /// <param name="columnIndex">列索引</param>
        /// <param name="width">宽度</param>
        IExport ColumnWidth( int columnIndex, int width );
        /// <summary>
        /// 设置表头样式
        /// </summary>
        /// <param name="style">单元格样式</param>
        IExport HeadStyle( CellStyle style );
        /// <summary>
        /// 设置正文样式
        /// </summary>
        /// <param name="style">单元格样式</param>
        IExport BodyStyle( CellStyle style );
        /// <summary>
        /// 设置页脚样式
        /// </summary>
        /// <param name="style">单元格样式</param>
        IExport FootStyle( CellStyle style );
        /// <summary>
        /// 添加表头
        /// </summary>
        /// <param name="titles">列标题</param>
        IExport Head( params string[] titles );
        /// <summary>
        /// 添加表头
        /// </summary>
        /// <param name="cells">单元格集合</param>
        IExport Head( params Cell[] cells );
        /// <summary>
        /// 添加正文
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">实体集合</param>
        IExport Body<T>( IEnumerable<T> list ) where T : class;
        /// <summary>
        /// 添加正文
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">实体集合</param>
        /// <param name="propertiesExpression">属性列表表达式，范例：t => new object[]{t.A,t.B}</param>
        IExport Body<T>( IEnumerable<T> list, Expression<Func<T, object[]>> propertiesExpression ) where T : class;
        /// <summary>
        /// 添加正文
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">实体集合</param>
        /// <param name="propertyNames">属性列表,范例："A","B"</param>
        IExport Body<T>( IEnumerable<T> list, params string[] propertyNames ) where T : class;
        /// <summary>
        /// 添加页脚
        /// </summary>
        /// <param name="values">值</param>
        IExport Foot( params string[] values );
        /// <summary>
        /// 添加页脚
        /// </summary>
        /// <param name="cells">单元格集合</param>
        IExport Foot( params Cell[] cells );
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="directory">目录，不包括文件名</param>
        /// <param name="fileName">文件名，不包括扩展名</param>
        IExport Write( string directory,string fileName = "" );
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="fileName">文件名，不包括扩展名</param>
        Task DownloadAsync( string fileName = "" );
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="fileName">文件名，不包括扩展名</param>
        /// <param name="encoding">字符编码</param>
        Task DownloadAsync( string fileName, Encoding encoding );
    }
}
