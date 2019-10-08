using Util.Ui.Builders;

namespace Util.Ui.Material.Toolbars.Builders {
    /// <summary>
    /// Mat工具栏填充项生成器
    /// </summary>
    public class ToolbarFillRemainBuilder : TagBuilder {
        /// <summary>
        /// 初始化工具栏填充项生成器
        /// </summary>
        public ToolbarFillRemainBuilder() : base( "span" ) {
            Class( "toolbar-fill-remain" );
        }
    }
}