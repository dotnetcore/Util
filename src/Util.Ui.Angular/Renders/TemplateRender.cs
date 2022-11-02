﻿using System;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Angular.Renders {
    /// <summary>
    /// ng-template模板渲染器
    /// </summary>
    public class TemplateRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化模板渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TemplateRender( Config config ) {
            _config = config ?? throw new ArgumentNullException( nameof( config ) );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TemplateBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}