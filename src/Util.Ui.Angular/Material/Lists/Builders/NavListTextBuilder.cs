using Util.Ui.Builders;

namespace Util.Ui.Material.Lists.Builders {
    /// <summary>
    /// Mat导航列表文本生成器
    /// </summary>
    public class NavListTextBuilder : TagBuilder {
        /// <summary>
        /// 初始化导航列表文本生成器
        /// </summary>
        public NavListTextBuilder() : base( "span" ) {
            AddAttribute( "mat-line" );
        }
    }
}