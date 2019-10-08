using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Maps;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Grid.Configs;
using Util.Ui.Zorro.Grid.Renders;

namespace Util.Ui.Zorro.Grid {
    /// <summary>
    /// 栅格布局
    /// </summary>
    [HtmlTargetElement( "util-grid")]
    public class GridTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 是否显示表单标签，默认值：false
        /// </summary>
        public bool ShowLabel { get; set; }
        /// <summary>
        /// 标签在栅格布局中的占位格数
        /// </summary>
        public int LabelSpan { get; set; }
        /// <summary>
        /// 控件在栅格布局中的占位格数
        /// </summary>
        public int ControlSpan { get; set; }
        /// <summary>
        /// 栅格列的占位格数
        /// </summary>
        public int ColumnSpan { get; set; }
        /// <summary>
        /// 表单项是否开启浮动布局
        /// </summary>
        public bool FormItemFlex { get; set; }
        /// <summary>
        /// 标签与控件之间间隔，可以是数字，单位为像素，也可以是响应式写法,范例：{ xs: 8, sm: 16, md: 24, lg: 32, xl: 32, xxl: 32 }
        /// </summary>
        public string Gutter { get; set; }
        /// <summary>
        /// 自动创建栅格列，默认值：false
        /// </summary>
        public bool AutoCreateColumn { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new GridRender( new Config( context ) );
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
            if( context.AllAttributes.ContainsName( UiConst.ShowLabel ) )
                config.ShowLabel = context.GetValueFromAttributes<bool>( UiConst.ShowLabel );
            if( context.AllAttributes.ContainsName( UiConst.LabelSpan ) )
                config.LabelSpan = context.GetValueFromAttributes<string>( UiConst.LabelSpan );
            if( context.AllAttributes.ContainsName( UiConst.ControlSpan ) )
                config.ControlSpan = context.GetValueFromAttributes<string>( UiConst.ControlSpan );
            if( context.AllAttributes.ContainsName( UiConst.ColumnSpan ) )
                config.ColumnSpan = context.GetValueFromAttributes<string>( UiConst.ColumnSpan );
            if( context.AllAttributes.ContainsName( UiConst.FormItemFlex ) )
                config.FormItemFlex = context.GetValueFromAttributes<bool>( UiConst.FormItemFlex );
            if( context.AllAttributes.ContainsName( UiConst.Gutter ) )
                config.Gutter = context.GetValueFromAttributes<string>( UiConst.Gutter );
            if( context.AllAttributes.ContainsName( UiConst.AutoCreateColumn ) )
                config.AutoCreateColumn = context.GetValueFromAttributes<bool>( UiConst.AutoCreateColumn );
        }
    }
}