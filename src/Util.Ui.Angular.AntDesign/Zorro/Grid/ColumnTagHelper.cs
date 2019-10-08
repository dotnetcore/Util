using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Maps;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Grid.Configs;
using Util.Ui.Zorro.Grid.Renders;

namespace Util.Ui.Zorro.Grid {
    /// <summary>
    /// 栅格布局 - 列
    /// </summary>
    [HtmlTargetElement( "util-column")]
    public class ColumnTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzSpan],24栅格占位格数，可选值: 0 - 24, 为 0 时隐藏
        /// </summary>
        public int Span { get; set; }
        /// <summary>
        /// [nzOffset],栅格偏移的格数
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// [nzOrder],栅格顺序
        /// </summary>
        public new int Order { get; set; }
        /// <summary>
        /// [nzPull],栅格向左移动的格数
        /// </summary>
        public int Pull { get; set; }
        /// <summary>
        /// [nzPush],栅格向右移动的格数
        /// </summary>
        public int Push { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ColumnRender( new Config( context ) );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">上下文</param>
        protected override void ProcessBefore( Context context ) {
            var shareConfig = context.GetValueFromItems<GridShareConfig>();
            if( shareConfig == null )
                return;
            var config = shareConfig.MapTo<GridShareConfig>();
            config.AutoCreateColumn = false;
            context.SetValueToItems( config );
        }
    }
}