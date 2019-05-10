using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Util.Helpers;
using Convert = Util.Helpers.Convert;

namespace Util.Tools.Offices.Core {
    /// <summary>
    /// 导出器
    /// </summary>
    public abstract class ExportBase : IExport {
        /// <summary>
        /// 表
        /// </summary>
        protected readonly Table Table;
        /// <summary>
        /// 导出格式
        /// </summary>
        private readonly ExportFormat _format;
        /// <summary>
        /// 表头样式
        /// </summary>
        private CellStyle _headStyle;
        /// <summary>
        /// 正文样式
        /// </summary>
        private CellStyle _bodyStyle;
        /// <summary>
        /// 页脚样式
        /// </summary>
        private CellStyle _footStyle;

        /// <summary>
        /// 初始化导出
        /// </summary>
        /// <param name="format">导出格式</param>
        protected ExportBase( ExportFormat format ) {
            Table = new Table();
            _format = format;
            _headStyle = CellStyle.Head();
            _bodyStyle = CellStyle.Body();
            _footStyle = CellStyle.Foot();
        }

        /// <summary>
        /// 列宽
        /// </summary>
        /// <param name="columnIndex">列索引</param>
        /// <param name="width">宽度</param>
        public abstract IExport ColumnWidth( int columnIndex, int width );

        /// <summary>
        /// 设置日期格式
        /// </summary>
        /// <param name="format">日期格式，默认"yyyy-mm-dd"</param>
        public abstract IExport DateFormat( string format = "yyyy-mm-dd" );

        /// <summary>
        /// 设置表头样式
        /// </summary>
        /// <param name="style">表头单元格样式</param>
        public IExport HeadStyle( CellStyle style ) {
            _headStyle = style;
            return this;
        }

        /// <summary>
        /// 获取表头样式
        /// </summary>
        protected CellStyle GetHeadStyle() {
            return _headStyle;
        }

        /// <summary>
        /// 设置正文样式
        /// </summary>
        /// <param name="style">单元格样式</param>
        public IExport BodyStyle( CellStyle style ) {
            _bodyStyle = style;
            return this;
        }

        /// <summary>
        /// 获取正文样式
        /// </summary>
        protected CellStyle GetBodyStyle() {
            return _bodyStyle;
        }

        /// <summary>
        /// 设置页脚样式
        /// </summary>
        /// <param name="style">单元格样式</param>
        public IExport FootStyle( CellStyle style ) {
            _footStyle = style;
            return this;
        }

        /// <summary>
        /// 获取页脚样式
        /// </summary>
        protected CellStyle GetFootStyle() {
            return _footStyle;
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        /// <param name="titles">列标题</param>
        public IExport Head( params string[] titles ) {
            Table.AddHeadRow( titles );
            return this;
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        /// <param name="cells">表头</param>
        public IExport Head( params Cell[] cells ) {
            Table.AddHeadRow( cells );
            return this;
        }

        /// <summary>
        /// 添加正文
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">实体集合</param>
        public IExport Body<T>( IEnumerable<T> list ) where T : class {
            return Body( list, typeof( T ).GetProperties().Select( t => t.Name ).ToArray() );
        }

        /// <summary>
        /// 添加正文
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">实体集合</param>
        /// <param name="propertiesExpression">属性表达式</param>
        public IExport Body<T>( IEnumerable<T> list, Expression<Func<T, object[]>> propertiesExpression )
            where T : class {
            return Body( list, Lambda.GetNames( propertiesExpression ).ToArray() );
        }

        /// <summary>
        /// 添加正文
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="data">数据</param>
        /// <param name="propertyNames">属性列表</param>
        public IExport Body<T>( IEnumerable<T> data, params string[] propertyNames ) where T : class {
            data.CheckNull( nameof( data ) );
            propertyNames.CheckNull( nameof( propertyNames ) );
            var list = data.ToList();
            foreach ( var entity in list )
                AddEntity( entity, propertyNames );
            AdjustColumnWidth( list.FirstOrDefault(), propertyNames );
            return this;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        private void AddEntity<T>( T entity, IEnumerable<string> propertyNames ) where T : class {
            var values = GetPropertyValues( entity, propertyNames );
            Table.AddBodyRow( values.ToArray() );
        }

        /// <summary>
        /// 获取属性值集合
        /// </summary>
        private List<object> GetPropertyValues<T>( T entity, IEnumerable<string> propertyNames ) where T : class {
            var type = entity.GetType();
            return propertyNames.Select( type.GetProperty ).Select( property => {
                if ( property == null )
                    return "";
                object result = property.GetValue( entity );
                if ( property.PropertyType == typeof( bool ) )
                    result = Convert.ToBool( result ).Description();
                return result;
            } ).ToList();
        }

        /// <summary>
        /// 调整列宽
        /// </summary>
        private void AdjustColumnWidth<T>( T entity, string[] propertyNames ) where T : class {
            if ( entity == null )
                return;
            var type = entity.GetType();
            for ( int i = 0; i < propertyNames.Length; i++ )
                AdjustColumnWidth( type.GetProperty( propertyNames[i] ), i );
        }

        /// <summary>
        /// 调整列宽
        /// </summary>
        private void AdjustColumnWidth( PropertyInfo property, int index ) {
            if ( property == null )
                return;
            if ( Reflection.IsDate( property ) )
                ColumnWidth( index, 12 );
        }

        /// <summary>
        /// 添加页脚
        /// </summary>
        /// <param name="values">值</param>
        public IExport Foot( params string[] values ) {
            Table.AddFootRow( values );
            return this;
        }

        /// <summary>
        /// 添加页脚
        /// </summary>
        /// <param name="cells">单元格集合</param>
        public IExport Foot( params Cell[] cells ) {
            Table.AddFootRow( cells );
            return this;
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="directory">目录，不包括文件名</param>
        /// <param name="fileName">文件名，不包括扩展名</param>
        public IExport Write( string directory, string fileName = "" ) {
            using ( var stream = new FileStream( GetFilePath( directory, fileName ), FileMode.Create ) ) {
                WriteStream( stream );
            }
            return this;
        }

        /// <summary>
        /// 获取文件路径
        /// </summary>
        private string GetFilePath( string directory, string fileName ) {
            return Path.Combine( directory, GetFileName( fileName ) );
        }

        /// <summary>
        /// 获取文件名
        /// </summary>
        private string GetFileName( string fileName ) {
            if ( fileName.IsEmpty() )
                fileName = Table.Title;
            if ( fileName.IsEmpty() )
                fileName = DateTime.Now.ToDateString();
            return fileName + "." + _format.ToString().ToLower();
        }

        /// <summary>
        /// 写入流
        /// </summary>
        /// <param name="stream">流</param>
        protected abstract void WriteStream( Stream stream );

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="fileName">文件名，不包括扩展名</param>
        public async Task DownloadAsync( string fileName = "" ) {
             await DownloadAsync( fileName, Encoding.UTF8 );
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="fileName">文件名，不包括扩展名</param>
        /// <param name="encoding">字符编码</param>
        public async Task DownloadAsync( string fileName, Encoding encoding ) {
            using( var stream = new MemoryStream() ) {
                WriteStream( stream );
                await Web.DownloadAsync( stream.ToArray(), GetFileName( fileName ) );
            }
        }
    }
}
