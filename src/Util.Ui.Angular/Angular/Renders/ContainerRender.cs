using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Renders;

namespace Util.Ui.Angular.Renders {
    /// <summary>
    /// ng-container容器渲染器
    /// </summary>
    public class ContainerRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化ng-container容器
        /// </summary>
        /// <param name="config">配置</param>
        public ContainerRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ContainerBuilder();
            builder.AddAttribute( "id", _config.GetValue( UiConst.Id ) );
            builder.SetContent( _config.Content );
            builder.AddOutputAttributes( _config );
            return builder;
        }
    }
}