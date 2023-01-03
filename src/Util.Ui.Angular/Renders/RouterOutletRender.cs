using Microsoft.AspNetCore.Html;
using System;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Angular.Renders {
    /// <summary>
    /// router-outlet路由出口渲染器
    /// </summary>
    public class RouterOutletRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化router-outlet路由出口渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public RouterOutletRender( Config config ) {
            _config = config ?? throw new ArgumentNullException( nameof( config ) );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new RouterOutletBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new RouterOutletRender( _config.Copy() );
        }
    }
}