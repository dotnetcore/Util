using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Drawers.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Drawers {
    /// <summary>
    /// 抽屉,生成的标签为&lt;nz-drawer>&lt;/nz-drawer>
    /// </summary>
    [HtmlTargetElement( "util-drawer" )]
    public class DrawerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzClosable],是否可关闭,默认值: true
        /// </summary>
        public bool Closable { get; set; }
        /// <summary>
        /// [nzClosable],是否可关闭,默认值: true
        /// </summary>
        public string BindClosable { get; set; }
        /// <summary>
        /// nzCloseIcon,自定义关闭图标,类型: string | TemplateRef&lt;void> | null,默认值: 'close'
        /// </summary>
        public AntDesignIcon CloseIcon { get; set; }
        /// <summary>
        /// [nzCloseIcon],自定义关闭图标,类型: string | TemplateRef&lt;void> | null,默认值: 'close'
        /// </summary>
        public string BindCloseIcon { get; set; }
        /// <summary>
        /// [nzMaskClosable],点击遮罩是否允许关闭,默认值: true
        /// </summary>
        public bool MaskClosable { get; set; }
        /// <summary>
        /// [nzMaskClosable],点击遮罩是否允许关闭,默认值: true
        /// </summary>
        public string BindMaskClosable { get; set; }
        /// <summary>
        /// [nzMask],是否显示遮罩,默认值: true
        /// </summary>
        public bool Mask { get; set; }
        /// <summary>
        /// [nzMask],是否显示遮罩,默认值: true
        /// </summary>
        public string BindMask { get; set; }
        /// <summary>
        /// [nzCloseOnNavigation],导航时是否关闭,当用户在历史中前进/后退时是否关闭抽屉,注意:这通常不包括点击链接（除非用户使用HashLocationStrategy）。默认值: true
        /// </summary>
        public bool CloseOnNavigation { get; set; }
        /// <summary>
        /// [nzCloseOnNavigation],导航时是否关闭,当用户在历史中前进/后退时是否关闭抽屉,注意:这通常不包括点击链接（除非用户使用HashLocationStrategy）。默认值: true
        /// </summary>
        public string BindCloseOnNavigation { get; set; }
        /// <summary>
        /// [nzMaskStyle],遮罩样式,类型: object,默认值: {}
        /// </summary>
        public string MaskStyle { get; set; }
        /// <summary>
        /// [nzKeyboard],是否支持键盘ESC键关闭,默认值: true
        /// </summary>
        public bool Keyboard { get; set; }
        /// <summary>
        /// [nzKeyboard],是否支持键盘ESC键关闭,默认值: true
        /// </summary>
        public string BindKeyboard { get; set; }
        /// <summary>
        /// [nzBodyStyle],主体样式,类型: object,默认值: {}
        /// </summary>
        public string BodyStyle { get; set; }
        /// <summary>
        /// nzTitle,标题,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],标题,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// nzFooter,页脚,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Footer { get; set; }
        /// <summary>
        /// [nzFooter],页脚,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindFooter { get; set; }
        /// <summary>
        /// [nzVisible],是否可见
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// [nzVisible],是否可见
        /// </summary>
        public string BindVisible { get; set; }
        /// <summary>
        /// [(nzVisible)],是否可见
        /// </summary>
        public string BindonVisible { get; set; }
        /// <summary>
        /// nzPlacement,抽屉方向,可选值: 'top' | 'right' | 'bottom' | 'left',默认值: 'right'
        /// </summary>
        public DrawerPlacement Placement { get; set; }
        /// <summary>
        /// [nzPlacement],抽屉方向,可选值: 'top' | 'right' | 'bottom' | 'left',默认值: 'right'
        /// </summary>
        public string BindPlacement { get; set; }
        /// <summary>
        /// nzWidth,宽度, 只在方向为 'right'或'left' 时生效,类型: number | string,默认值: 256
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// [nzWidth],宽度, 只在方向为 'right'或'left' 时生效,类型: number | string,默认值: 256
        /// </summary>
        public string BindWidth { get; set; }
        /// <summary>
        /// nzHeight,高度, 只在方向为 'top'或'bottom' 时生效,类型: number | string,默认值: 256
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// [nzHeight],高度, 只在方向为 'top'或'bottom' 时生效,类型: number | string,默认值: 256
        /// </summary>
        public string BindHeight { get; set; }
        /// <summary>
        /// nzOffsetX,X坐标偏移量,单位:像素,只在方向为 'right'或'left' 时生效,类型: number,默认值: 0
        /// </summary>
        public double OffsetX { get; set; }
        /// <summary>
        /// [nzOffsetX],X坐标偏移量,单位:像素,只在方向为 'right'或'left' 时生效,类型: number,默认值: 0
        /// </summary>
        public string BindOffsetX { get; set; }
        /// <summary>
        /// nzOffsetY,Y坐标偏移量,单位:像素,只在方向为 'top'或'bottom' 时生效,类型: number,默认值: 0
        /// </summary>
        public double OffsetY { get; set; }
        /// <summary>
        /// [nzOffsetY],Y坐标偏移量,单位:像素,只在方向为 'top'或'bottom' 时生效,类型: number,默认值: 0
        /// </summary>
        public string BindOffsetY { get; set; }
        /// <summary>
        /// nzWrapClassName,对话框外层容器样式类名
        /// </summary>
        public string WrapClassName { get; set; }
        /// <summary>
        /// [nzWrapClassName],对话框外层容器样式类名
        /// </summary>
        public string BindWrapClassName { get; set; }
        /// <summary>
        /// nzZIndex,z-index,类型: number,默认值: 1000
        /// </summary>
        public int ZIndex { get; set; }
        /// <summary>
        /// [nzZIndex],z-index,类型: number,默认值: 1000
        /// </summary>
        public string BindZIndex { get; set; }
        /// <summary>
        /// (nzOnClose),关闭事件,点击遮罩层或右上角叉时触发,类型: EventEmitter&lt;MouseEvent>
        /// </summary>
        public string OnClose { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new DrawerRender( config );
        }
    }
}