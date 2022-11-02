using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Layouts.Builders {
    /// <summary>
    /// 内容区布局标签生成器
    /// </summary>
    public class ContentBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化内容区布局标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ContentBuilder( Config config ) : base( config,"nz-content" ) {
        }
    }
}