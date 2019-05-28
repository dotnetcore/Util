using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Util.Tools.Offices.Npoi {
    /// <summary>
    /// Npoi Excel2007操作
    /// </summary>
    public class Excel2007 : ExcelBase {
        /// <summary>
        /// 创建工作薄
        /// </summary>
        protected override IWorkbook GetWorkbook() {
            return new XSSFWorkbook();
        }
    }
}
