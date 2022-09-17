﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Layouts.Renders;

namespace Util.Ui.NgZorro.Components.Layouts {
    /// <summary>
    /// 内容区布局,生成的标签为&lt;nz-content&gt;&lt;/nz-content&gt;,它的父容器为&lt;util-layout&gt;&lt;/util-layout&gt;,即&lt;nz-layout&gt;&lt;/nz-layout&gt;
    /// </summary>
    [HtmlTargetElement( "util-content" )]
    public class ContentTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ContentRender( config );
        }
    }
}