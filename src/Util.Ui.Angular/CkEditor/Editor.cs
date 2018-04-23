using Util.Ui.CkEditor.Renders;
using Util.Ui.Components;
using Util.Ui.Renders;

namespace Util.Ui.CkEditor {
    /// <summary>
    /// 富文本框编辑器
    /// </summary>
    public class Editor : ComponentBase, IEditor {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new EditorRender( OptionConfig );
        }
    }
}