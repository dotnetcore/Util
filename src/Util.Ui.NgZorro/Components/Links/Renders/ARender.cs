﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Links.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Links.Renders {
    /// <summary>
    /// 链接渲染器
    /// </summary>
    public class ARender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化链接渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ARender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ABuilder( _config );
            builder.Config();
            return builder;
        }
    }
}