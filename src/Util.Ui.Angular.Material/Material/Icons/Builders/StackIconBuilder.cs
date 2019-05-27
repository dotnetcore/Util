using Util.Ui.Builders;

namespace Util.Ui.Material.Icons.Builders {
    /// <summary>
    /// 堆叠图标生成器
    /// </summary>
    public class StackIconBuilder : TagBuilder {
        /// <summary>
        /// 初始化堆叠图标生成器
        /// </summary>
        public StackIconBuilder() : base( "span" ) {
            Class( "fa-stack" );
        }
    }
}
