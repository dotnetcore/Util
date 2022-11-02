﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Checkboxes.Builders;

namespace Util.Ui.NgZorro.Components.Checkboxes.Renders {
    /// <summary>
    /// 复选框包装器渲染器
    /// </summary>
    public class CheckboxWrapperRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化复选框包装器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CheckboxWrapperRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 添加表单控件
        /// </summary>
        protected override void AppendControl( TagBuilder formControlBuilder ) {
            var builder = new CheckboxWrapperBuilder( _config );
            builder.Config();
            _config.Content.AppendTo( builder );
            formControlBuilder.AppendContent( builder );
        }
    }
}