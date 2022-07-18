﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Util.Ui.TagHelpers {
    /// <summary>
    /// TagHelper基类
    /// </summary>
    public abstract class TagHelperBase : TagHelper {
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// style,样式
        /// </summary>
        public string Style { get; set; }
        /// <summary>
        /// class,样式类
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// [hidden],是否隐藏
        /// </summary>
        public string Hidden { get; set; }

        /// <summary>
        /// 转换为包装器
        /// </summary>
        public TagHelperWrapper ToWrapper() {
            return new TagHelperWrapper( this );
        }

        /// <summary>
        /// 渲染
        /// </summary>
        public override async Task ProcessAsync( TagHelperContext context, TagHelperOutput output ) {
            ProcessBefore( context, output );
            var content = await output.GetChildContentAsync();
            var render = GetRender( context, output, content );
            output.SuppressOutput();
            output.PostElement.SetHtmlContent( render );
            ProcessAfter( context, output, content, render );
        }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        protected virtual void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        /// <param name="content">内容</param>
        protected abstract IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content );

        /// <summary>
        /// 渲染后操作
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        /// <param name="content">内容</param>
        /// <param name="render">渲染器</param>
        protected virtual void ProcessAfter( TagHelperContext context, TagHelperOutput output, TagHelperContent content, IHtmlContent render ) {
        }
    }
}
