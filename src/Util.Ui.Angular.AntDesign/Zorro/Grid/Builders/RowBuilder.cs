using Util.Ui.Builders;

namespace Util.Ui.Zorro.Grid.Builders {
    /// <summary>
    /// NgZorro栅格行生成器
    /// </summary>
    public class RowBuilder : TagBuilder {
        /// <summary>
        /// 初始化栅格行生成器
        /// </summary>
        public RowBuilder() : base( "div" ) {
            base.AddAttribute( "nz-row" );
        }
    }
}