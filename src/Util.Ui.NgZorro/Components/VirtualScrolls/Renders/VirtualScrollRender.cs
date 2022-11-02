﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.VirtualScrolls.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.VirtualScrolls.Renders {
    /// <summary>
    /// 虚拟滚动渲染器
    /// </summary>
    public class VirtualScrollRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化虚拟滚动渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public VirtualScrollRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new VirtualScrollBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}