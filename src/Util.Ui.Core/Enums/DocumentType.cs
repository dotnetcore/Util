using System.ComponentModel;
using Util.Ui.Helpers;

namespace Util.Ui.Enums {
    /// <summary>
    /// 文档类型
    /// </summary>
    public enum DocumentType {
        /// <summary>
        /// xls,xlsx
        /// </summary>
        [Description( "application/x-xls,application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" )]
        Xls,
        /// <summary>
        /// doc,docx
        /// </summary>
        [Description( "application/msword,application/vnd.openxmlformats-officedocument.wordprocessingml.document" )]
        Doc,
        /// <summary>
        /// pdf
        /// </summary>
        [Description( "application/pdf" )]
        Pdf,
        /// <summary>
        /// txt
        /// </summary>
        [Description( "text/plain" )]
        Txt
    }

    /// <summary>
    /// 文档类型枚举扩展
    /// </summary>
    public static class DocumentTypeExtensions {
        /// <summary>
        /// 获取文档类型扩展名列表
        /// </summary>
        public static string GetExtensions( this DocumentType fileType ) {
            var name = Util.Helpers.Enum.GetName<DocumentType>( fileType );
            return FileTypeHelper.GetExtensions( name );
        }
    }
}
