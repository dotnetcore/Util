﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Skeletons.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Skeletons.Renders {
    /// <summary>
    /// 骨架屏渲染器
    /// </summary>
    public class SkeletonRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化骨架屏渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SkeletonRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SkeletonBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}