using Util.Ui.Builders;

namespace Util.Ui.CkEditor.Builders {
    /// <summary>
    /// CKEditor富文本框编辑器生成器
    /// </summary>
    public class CkEditorBuilder : TagBuilder {
        /// <summary>
        /// 初始化富文本框编辑器生成器
        /// </summary>
        public CkEditorBuilder() : base( "ckeditor" ) {
        }
    }
}