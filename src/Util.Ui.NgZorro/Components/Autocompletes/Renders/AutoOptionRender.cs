﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Autocompletes.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Autocompletes.Renders {
    /// <summary>
    /// 自动完成项渲染器
    /// </summary>
    public class AutoOptionRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化自动完成项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public AutoOptionRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AutoOptionBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}