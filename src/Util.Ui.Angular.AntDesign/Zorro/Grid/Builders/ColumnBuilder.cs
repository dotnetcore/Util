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

        /// <summary>
        /// 添加跨度
        /// </summary>
        /// <param name="span">占位格数</param>
        public void AddSpan( string span ) {
            AddAttribute( "[nzSpan]", span );
        }
    }
}