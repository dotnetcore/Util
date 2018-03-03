using Util.Ui.Builders;

namespace Util.Ui.Material.Lists.Builders {
    /// <summary>
    /// Mat列表头部生成器
    /// </summary>
    public class ListHeaderBuilder : TagBuilder {
        /// <summary>
        /// 初始化列表头部生成器
        /// </summary>
        public ListHeaderBuilder() : base( "h3" ) {
            AddAttribute( "mat-subheader" );
        }
    }
}