using System;

namespace Util.Tools.Offices.Npoi {
    /// <summary>
    /// 导出操作工厂
    /// </summary>
    public class ExportFactory : IExportFactory {
        /// <summary>
        /// 创建导出器
        /// </summary>
        /// <param name="format">导出格式</param>
        public IExport Create( ExportFormat format = ExportFormat.Xlsx ) {
            switch( format ) {
                case ExportFormat.Xlsx:
                    return CreateExcel2007Export();
                case ExportFormat.Xls:
                    return CreateExcel2003Export();
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建Npoi Excel 2003导出器
        /// </summary>
        public static IExport CreateExcel2003Export() {
            return new Excel2003Export();
        }

        /// <summary>
        /// 创建Npoi Excel 2007导出器
        /// </summary>
        public static IExport CreateExcel2007Export() {
            return new Excel2007Export();
        }
    }
}
