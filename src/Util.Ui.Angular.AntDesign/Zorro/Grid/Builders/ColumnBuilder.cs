using Util.Ui.Builders;

namespace Util.Ui.Zorro.Grid.Builders {
    /// <summary>
    /// NgZorro栅格列生成器
    /// </summary>
    public class ColumnBuilder : TagBuilder {
        /// <summary>
        /// 初始化栅格列生成器
        /// </summary>
        public ColumnBuilder() : base( "div" ) {
            base.AddAttribute( "nz-col" );
        }
    }
}