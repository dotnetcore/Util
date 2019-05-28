using Util.Tools.Offices.Core;

namespace Util.Tools.Offices.Npoi {
    /// <summary>
    /// Npoi Excel2003 导出操作
    /// </summary>
    public class Excel2003Export : ExcelExportBase {
        /// <summary>
        /// 初始化Npoi Excel2003 导出操作
        /// </summary>
        public Excel2003Export() 
            : base ( ExportFormat.Xls, new Excel2003() ){
        }
    }
}
