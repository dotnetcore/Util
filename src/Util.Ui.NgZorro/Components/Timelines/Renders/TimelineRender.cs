﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Timelines.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Timelines.Renders {
    /// <summary>
    /// 时间轴渲染器
    /// </summary>
    public class TimelineRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化时间轴渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TimelineRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TimelineBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}