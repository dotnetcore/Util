using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Renders {
    /// <summary>
    /// 组件渲染器
    /// </summary>
    /// <typeparam name="TTagBuilder">标签生成器类型</typeparam>
    /// <typeparam name="TConfig">配置类型</typeparam>
    public class ComponentRender<TTagBuilder, TConfig> : RenderBase<TTagBuilder, TConfig> 
        where TTagBuilder: ITagBuilder 
        where TConfig : IConfig {
        /// <summary>
        /// 初始化组件渲染器
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">组件配置</param>
        public ComponentRender( TTagBuilder builder, TConfig config ) : base( builder, config ) {
        }
    }
}
