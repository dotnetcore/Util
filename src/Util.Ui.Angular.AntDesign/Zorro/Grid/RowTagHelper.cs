using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Maps;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Grid.Configs;
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
        /// 是否flex布局模式，默认值：false
        /// </summary>
        public bool IsFlex { get; set; }
        /// <summary>
        /// nzAlign,垂直对齐方式
        /// </summary>
        public Align Align { get; set; }
        /// <summary>
        /// nzJustify,水平排列方式
        /// </summary>
        public Justify Justify { get; set; }
        /// <summary>
        /// 栅格列的占位格数
        /// </summary>
        public int ColumnSpan { get; set; }
        /// <summary>
        /// 自动创建栅格列，默认值：false
        /// </summary>
        public bool AutoCreateColumn { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RowRender( new Config( context ) );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">上下文</param>
        protected override void ProcessBefore( Context context ) {
            var shareConfig = context.GetValueFromItems<GridShareConfig>();
            var config = shareConfig.MapTo<GridShareConfig>() ?? new GridShareConfig();
            InitShareConfig( context.TagHelperContext, config );
            context.SetValueToItems( config );
        }

        /// <summary>
        /// 初始化共享配置
        /// </summary>
        protected virtual void InitShareConfig( TagHelperContext context, GridShareConfig config ) {
            if( context.AllAttributes.ContainsName( UiConst.ColumnSpan ) )
                config.ColumnSpan = context.GetValueFromAttributes<string>( UiConst.ColumnSpan );
            if( context.AllAttributes.ContainsName( UiConst.AutoCreateColumn ) )
                config.AutoCreateColumn = context.GetValueFromAttributes<bool>( UiConst.AutoCreateColumn );
        }
    }
}