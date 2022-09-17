using Util.Ui.Angular.TagHelpers;

namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 栅格列基类
    /// </summary>
    public abstract class ColumnTagHelperBase : AngularTagHelperBase {
        /// <summary>
        /// nzSpan,24栅格占位格数，可选值: 0 - 24, 为 0 时隐藏
        /// </summary>
        public int Span { get; set; }
        /// <summary>
        /// [nzSpan],24栅格占位格数，可选值: 0 - 24, 为 0 时隐藏
        /// </summary>
        public string BindSpan { get; set; }
        /// <summary>
        /// nzOffset,栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,范例: 设置值为4,将元素向右侧偏移4格宽度
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// [nzOffset],栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,范例: 设置值为4,将元素向右侧偏移4格宽度
        /// </summary>
        public string BindOffset { get; set; }
        /// <summary>
        /// nzOrder,栅格顺序
        /// </summary>
        public new int Order { get; set; }
        /// <summary>
        /// [nzOrder],栅格顺序
        /// </summary>
        public string BindOrder { get; set; }
        /// <summary>
        /// nzPull,栅格向左移动的格数
        /// </summary>
        public int Pull { get; set; }
        /// <summary>
        /// [nzPull],栅格向左移动的格数
        /// </summary>
        public string BindPull { get; set; }
        /// <summary>
        /// nzPush,栅格向右移动的格数
        /// </summary>
        public int Push { get; set; }
        /// <summary>
        /// [nzPush],栅格向右移动的格数
        /// </summary>
        public string BindPush { get; set; }
        /// <summary>
        /// nzFlex,Flex布局
        /// </summary>
        public string Flex { get; set; }
        /// <summary>
        /// [nzFlex],Flex布局
        /// </summary>
        public string BindFlex { get; set; }
        /// <summary>
        /// [nzXs], &lt;576px超窄尺寸响应式栅格,可以设置一个数字,相当于[nzXs]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string Xs { get; set; }
        /// <summary>
        /// &lt;576px超窄尺寸响应式栅格占位格数，可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzXs]="{span:6}"
        /// </summary>
        public int XsSpan { get; set; }
        /// <summary>
        /// &lt;576px超窄尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzXs]="{offset:6}"
        /// </summary>
        public int XsOffset { get; set; }
        /// <summary>
        /// &lt;576px超窄尺寸响应式栅格顺序,范例: 设置值为6,生成[nzXs]="{order:6}"
        /// </summary>
        public int XsOrder { get; set; }
        /// <summary>
        /// &lt;576px超窄尺寸响应式栅格向左移动的格数,范例: 设置值为6,生成[nzXs]="{pull:6}"
        /// </summary>
        public int XsPull { get; set; }
        /// <summary>
        /// &lt;576px超窄尺寸响应式栅格向右移动的格数,范例: 设置值为6,生成[nzXs]="{push:6}"
        /// </summary>
        public int XsPush { get; set; }
        /// <summary>
        /// [nzSm], ≥576px窄尺寸响应式栅格,可以设置一个数字,相当于[nzSm]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string Sm { get; set; }
        /// <summary>
        /// ≥576px窄尺寸响应式栅格占位格数，可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzSm]="{span:6}"
        /// </summary>
        public int SmSpan { get; set; }
        /// <summary>
        /// ≥576px窄尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzSm]="{offset:6}"
        /// </summary>
        public int SmOffset { get; set; }
        /// <summary>
        /// ≥576px窄尺寸响应式栅格顺序,范例: 设置值为6,生成[nzSm]="{order:6}"
        /// </summary>
        public int SmOrder { get; set; }
        /// <summary>
        /// ≥576px窄尺寸响应式栅格向左移动的格数,范例: 设置值为6,生成[nzSm]="{pull:6}"
        /// </summary>
        public int SmPull { get; set; }
        /// <summary>
        /// ≥576px窄尺寸响应式栅格向右移动的格数,范例: 设置值为6,生成[nzSm]="{push:6}"
        /// </summary>
        public int SmPush { get; set; }
        /// <summary>
        /// [nzMd], ≥768px中尺寸响应式栅格,可以设置一个数字,相当于[nzMd]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string Md { get; set; }
        /// <summary>
        /// ≥768px中尺寸响应式栅格占位格数，可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzMd]="{span:6}"
        /// </summary>
        public int MdSpan { get; set; }
        /// <summary>
        /// ≥768px中尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzMd]="{offset:6}"
        /// </summary>
        public int MdOffset { get; set; }
        /// <summary>
        /// ≥768px中尺寸响应式栅格顺序,范例: 设置值为6,生成[nzMd]="{order:6}"
        /// </summary>
        public int MdOrder { get; set; }
        /// <summary>
        /// ≥768px中尺寸响应式栅格向左移动的格数,范例: 设置值为6,生成[nzMd]="{pull:6}"
        /// </summary>
        public int MdPull { get; set; }
        /// <summary>
        /// ≥768px中尺寸响应式栅格向右移动的格数,范例: 设置值为6,生成[nzMd]="{push:6}"
        /// </summary>
        public int MdPush { get; set; }
        /// <summary>
        /// [nzLg], ≥992px宽尺寸响应式栅格,可以设置一个数字,相当于[nzLg]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string Lg { get; set; }
        /// <summary>
        /// ≥992px宽尺寸响应式栅格占位格数，可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzLg]="{span:6}"
        /// </summary>
        public int LgSpan { get; set; }
        /// <summary>
        /// ≥992px宽尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzLg]="{offset:6}"
        /// </summary>
        public int LgOffset { get; set; }
        /// <summary>
        /// ≥992px宽尺寸响应式栅格顺序,范例: 设置值为6,生成[nzLg]="{order:6}"
        /// </summary>
        public int LgOrder { get; set; }
        /// <summary>
        /// ≥992px宽尺寸响应式栅格向左移动的格数,范例: 设置值为6,生成[nzLg]="{pull:6}"
        /// </summary>
        public int LgPull { get; set; }
        /// <summary>
        /// ≥992px宽尺寸响应式栅格向右移动的格数,范例: 设置值为6,生成[nzLg]="{push:6}"
        /// </summary>
        public int LgPush { get; set; }
        /// <summary>
        /// [nzXl], ≥1200px超宽尺寸响应式栅格,可以设置一个数字,相当于[nzXl]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string Xl { get; set; }
        /// <summary>
        /// ≥1200px超宽尺寸响应式栅格占位格数，可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzXl]="{span:6}"
        /// </summary>
        public int XlSpan { get; set; }
        /// <summary>
        /// ≥1200px超宽尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzXl]="{offset:6}"
        /// </summary>
        public int XlOffset { get; set; }
        /// <summary>
        /// ≥1200px超宽尺寸响应式栅格顺序,范例: 设置值为6,生成[nzXl]="{order:6}"
        /// </summary>
        public int XlOrder { get; set; }
        /// <summary>
        /// ≥1200px超宽尺寸响应式栅格向左移动的格数,范例: 设置值为6,生成[nzXl]="{pull:6}"
        /// </summary>
        public int XlPull { get; set; }
        /// <summary>
        /// ≥1200px超宽尺寸响应式栅格向右移动的格数,范例: 设置值为6,生成[nzXl]="{push:6}"
        /// </summary>
        public int XlPush { get; set; }
        /// <summary>
        /// [nzXXl], ≥1600px极宽尺寸响应式栅格,可以设置一个数字,相当于[nzXXl]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string Xxl { get; set; }
        /// <summary>
        /// ≥1600px极宽尺寸响应式栅格占位格数，可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzXXl]="{span:6}"
        /// </summary>
        public int XxlSpan { get; set; }
        /// <summary>
        /// ≥1600px极宽尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzXXl]="{offset:6}"
        /// </summary>
        public int XxlOffset { get; set; }
        /// <summary>
        /// ≥1600px极宽尺寸响应式栅格顺序,范例: 设置值为6,生成[nzXXl]="{order:6}"
        /// </summary>
        public int XxlOrder { get; set; }
        /// <summary>
        /// ≥1600px极宽尺寸响应式栅格向左移动的格数,范例: 设置值为6,生成[nzXXl]="{pull:6}"
        /// </summary>
        public int XxlPull { get; set; }
        /// <summary>
        /// ≥1600px极宽尺寸响应式栅格向右移动的格数,范例: 设置值为6,生成[nzXXl]="{push:6}"
        /// </summary>
        public int XxlPush { get; set; }
    }
}