using System.ComponentModel;

namespace Util.Ui.Enums {
    /// <summary>
    /// 文档类型
    /// </summary>
    public enum DocumentType {
        /// <summary>
        /// xls,xlsx
        /// </summary>
        [Description( ".xls,.xlsx" )]
        Xls,
        /// <summary>
        /// doc,docx
        /// </summary>
        [Description( ".doc,.docx" )]
        Doc,
        /// <summary>
        /// pdf
        /// </summary>
        [Description( ".pdf" )]
        Pdf,
        /// <summary>
        /// txt
        /// </summary>
        [Description( ".txt" )]
        Txt
    }
}
