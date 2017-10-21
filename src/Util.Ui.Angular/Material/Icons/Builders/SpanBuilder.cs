using Util.Ui.Builders;

namespace Util.Ui.Material.Icons.Builders {
    /// <summary>
    /// 堆叠图标Span生成器
    /// </summary>
    public class SpanBuilder : TagBuilder {
        /// <summary>
        /// 初始化堆叠图标Span生成器
        /// </summary>
        public SpanBuilder() : base( "span" ) {
            Class( "fa-stack" );
        }
    }
}
