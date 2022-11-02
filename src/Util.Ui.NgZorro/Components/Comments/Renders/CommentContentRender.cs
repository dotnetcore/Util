﻿using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Comments.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Comments.Renders {
    /// <summary>
    /// 评论内容渲染器
    /// </summary>
    public class CommentContentRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化评论内容渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CommentContentRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CommentContentBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}