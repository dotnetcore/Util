using Util.Ui.Builders;

namespace Util.Ui.Material.Lists.Builders {
    /// <summary>
    /// Mat列表内容生成器
    /// </summary>
    public class ListContentBuilder : TagBuilder {
        /// <summary>
        /// 初始化列表内容生成器
        /// </summary>
        public ListContentBuilder() : base( "p" ) {
            AddAttribute( "matLine" );
        }
    }
}