using Util.Ui.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Components {
    /// <summary>
    /// 标题
    /// </summary>
    public class Heading : ComponentBase, IHeading {
        /// <summary>
        /// 标签
        /// </summary>
        private readonly string _tagName;

        /// <summary>
        /// 初始化标题
        /// </summary>
        /// <param name="tagName">标签</param>
        public Heading( string tagName ) {
            _tagName = tagName;
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return RenderFactory.Create( new TagBuilder( _tagName ), OptionConfig );
        }
    }
}
