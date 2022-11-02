﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Statistics.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Statistics.Renders {
    /// <summary>
    /// 倒计时渲染器
    /// </summary>
    public class CountdownRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化倒计时渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CountdownRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CountdownBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}