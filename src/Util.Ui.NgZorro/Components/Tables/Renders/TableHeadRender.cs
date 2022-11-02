﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tables.Renders {
    /// <summary>
    /// 表头渲染器
    /// </summary>
    public class TableHeadRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表头渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TableHeadRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableHeadBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}