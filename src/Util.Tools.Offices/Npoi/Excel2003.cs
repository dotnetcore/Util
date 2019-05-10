using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Util.Tools.Offices.Npoi {
    /// <summary>
    /// Npoi Excel2003操作
    /// </summary>
    public class Excel2003 : ExcelBase {
        /// <summary>
        /// 创建工作薄
        /// </summary>
        protected override IWorkbook GetWorkbook() {
            return new HSSFWorkbook();
        }
    }
}
