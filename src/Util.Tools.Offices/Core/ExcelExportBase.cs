using System.Collections.Generic;
using System.IO;
using Util.Tools.Offices.Abstractions;

namespace Util.Tools.Offices.Core {
    /// <summary>
    /// Excel导出
    /// </summary>
    public abstract class ExcelExportBase : ExportBase {
        /// <summary>
        /// 初始化Excel导出
        /// </summary>
        /// <param name="format">导出格式</param>
        /// <param name="excel">Excel操作</param>
        protected ExcelExportBase( ExportFormat format, IExcel excel )
            : base( format ) {
            _excel = excel;
        }

        /// <summary>
        /// Excel操作
        /// </summary>
        private readonly IExcel _excel;

        /// <summary>
        /// 列宽
        /// </summary>
        /// <param name="columnIndex">列索引</param>
        /// <param name="width">宽度</param>
        public override IExport ColumnWidth( int columnIndex, int width ) {
            _excel.ColumnWidth( columnIndex, width );
            return this;
        }

        /// <summary>
        /// 设置日期格式
        /// </summary>
        /// <param name="format">日期格式，默认"yyyy-mm-dd"</param>
        public override IExport DateFormat( string format = "yyyy-mm-dd" ) {
            _excel.DateFormat( format );
            return this;
        }

        /// <summary>
        /// 写入流
        /// </summary>
        /// <param name="stream">流</param>
        protected override void WriteStream( Stream stream ) {
            AddHeader();
            AddBody();
            AddFoot();
            _excel.Write( stream );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        private void AddHeader() {
            _excel.HeadStyle( Table, GetHeadStyle() );
            CreateRows( Table.GetHeader() );
        }

        /// <summary>
        /// 创建行
        /// </summary>
        private void CreateRows( IEnumerable<Row> rows ) {
            foreach ( var row in rows ) {
                _excel.CreateRow( row.RowIndex );
                foreach ( var cell in row.Cells )
                    _excel.CreateCell( cell );
            }
        }

        /// <summary>
        /// 添加正文
        /// </summary>
        private void AddBody() {
            _excel.BodyStyle( Table, GetBodyStyle() );
            CreateRows( Table.GetBody() );
        }

        /// <summary>
        /// 添加页脚
        /// </summary>
        private void AddFoot() {
            _excel.FootStyle( Table, GetFootStyle() );
            CreateRows( Table.GetFooter() );
        }
    }
}
