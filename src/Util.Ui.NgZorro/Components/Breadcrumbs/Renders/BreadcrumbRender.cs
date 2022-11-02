﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.BreadCrumbs.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.BreadCrumbs.Renders {
    /// <summary>
    /// 面包屑渲染器
    /// </summary>
    public class BreadcrumbRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化面包屑渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public BreadcrumbRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new BreadcrumbBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}