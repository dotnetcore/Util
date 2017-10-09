using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Renders {
    /// <summary>
    /// 组件渲染器工厂
    /// </summary>
    public static class RenderFactory {
        /// <summary>
        /// 创建组件渲染器
        /// </summary>
        /// <typeparam name="TTagBuilder">标签生成器类型</typeparam>
        /// <typeparam name="TConfig">配置类型</typeparam>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">组件配置</param>
        public static IRender Create<TTagBuilder, TConfig>( TTagBuilder builder, TConfig config )
            where TTagBuilder : ITagBuilder
            where TConfig : IConfig {
            return new ComponentRender<TTagBuilder, TConfig>( builder, config );
        }
    }
}
