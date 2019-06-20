﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Grid.Renders;

namespace Util.Ui.Zorro.Grid {
    /// <summary>
    /// 栅格布局 - 行
    /// </summary>
    [HtmlTargetElement( "util-row")]
    public class RowTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzGutter],栅格间隔，可以是数字，单位为像素，也可以是响应式写法,范例：{ xs: 8, sm: 16, md: 24, lg: 32, xl: 32, xxl: 32 }
        /// </summary>
        public string Gutter { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RowRender( new Config( context ) );
        }
    }
}