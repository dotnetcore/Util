using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Renders;

namespace Util.Ui.Angular.Renders {
    /// <summary>
    /// angular渲染器
    /// </summary>
    public abstract class AngularRenderBase : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化angular渲染器
        /// </summary>
        /// <param name="config">配置</param>
        protected AngularRenderBase( Config config ) : base( config ) {
            _config = config;
        }

        /// <inheritdoc />
        protected override void ConfigBuilder( TagBuilder builder ) {
            base.ConfigBuilder( builder );
            ConfigId( builder );
            builder.Angular( _config );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected virtual void ConfigId( TagBuilder builder ) {
            builder.RawId( _config );
            builder.Id( _config );
        }

        /// <summary>
        /// 配置内容元素
        /// </summary>
        protected virtual void ConfigContent( TagBuilder builder ) {
            _config.Content.AppendTo( builder );
        }
    }
}