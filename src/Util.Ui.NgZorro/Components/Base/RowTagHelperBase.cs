using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 栅格行基类
    /// </summary>
    public abstract class RowTagHelperBase : AngularTagHelperBase {
        /// <summary>
        /// nzAlign,垂直对齐方式
        /// </summary>
        public Align Align { get; set; }
        /// <summary>
        /// [nzAlign],垂直对齐方式,可选值: 'top' | 'middle' | 'bottom'
        /// </summary>
        public string BindAlign { get; set; }
        /// <summary>
        /// [nzGutter],栅格间隔，可以是数字，也可以是响应式写法,范例：{ xs: 8, sm: 16, md: 24, lg: 32, xl: 32, xxl: 32 }。或者使用数组形式同时设置 [水平间距, 垂直间距],范例:[16, 24]。取值推荐使用16+8n,n是自然数,单位为像素。
        /// </summary>
        public string Gutter { get; set; }
        /// <summary>
        /// nzJustify,水平排列方式
        /// </summary>
        public Justify Justify { get; set; }
        /// <summary>
        /// [nzJustify],水平排列方式,可选值: 'start' | 'end' | 'center' | 'space-around' | 'space-between'
        /// </summary>
        public string BindJustify { get; set; }
    }
}