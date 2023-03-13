using System;
using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Display.Builders;

namespace Util.Ui.NgZorro.Components.Display.Renders {
    /// <summary>
    /// 数据项展示标签渲染器
    /// </summary>
    public class DisplayRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化数据项展示标签渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DisplayRender( Config config ) : base( config ) {
            _config = config ?? throw new ArgumentNullException( nameof( config ) );
        }

        /// <summary>
        /// 添加表单控件
        /// </summary>
        protected override void AppendControl( TagBuilder formControlBuilder ) {
            var display = GetDisplayBuilder();
            formControlBuilder.AppendContent( display );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected TagBuilder GetDisplayBuilder() {
            var builder = new DisplayBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new DisplayRender( _config.Copy() );
        }
    }
}