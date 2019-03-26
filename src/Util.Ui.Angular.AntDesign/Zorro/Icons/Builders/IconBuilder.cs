using Util.Ui.Builders;

namespace Util.Ui.Zorro.Icons.Builders {
    /// <summary>
    /// 图标生成器
    /// </summary>
    public class IconBuilder : TagBuilder {
        /// <summary>
        /// 初始化图标生成器
        /// </summary>
        public IconBuilder() : base( "i" ) {
            AddAttribute( "nz-icon" );
        }
    }
}
