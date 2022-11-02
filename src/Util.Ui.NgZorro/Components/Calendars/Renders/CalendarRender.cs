﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Calendars.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Calendars.Renders {
    /// <summary>
    /// 日历渲染器
    /// </summary>
    public class CalendarRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化日历渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CalendarRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CalendarBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}