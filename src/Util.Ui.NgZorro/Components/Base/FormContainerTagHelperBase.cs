namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 表单容器基类
    /// </summary>
    public abstract class FormContainerTagHelperBase : RowTagHelperBase {
        /// <summary>
        /// 自动设置 nz-form-label 的 nzFor 属性,如果未设置控件Id,则自动创建Id
        /// </summary>
        public bool AutoLabelFor { get; set; }
        /// <summary>
        /// 标签栅格占位格数,设置 nz-form-label 的 [nzSpan] 属性,可选值: 0 - 24, 为 0 时隐藏
        /// </summary>
        public string LabelSpan { get; set; }
        /// <summary>
        /// 标签栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-label 的 [nzOffset] 属性,范例: 设置值为4,将标签向右侧偏移4格宽度
        /// </summary>
        public string LabelOffset { get; set; }
        /// <summary>
        /// 标签栅格顺序,设置 nz-form-label 的 [nzOrder] 属性
        /// </summary>
        public string LabelOrder { get; set; }
        /// <summary>
        /// 标签栅格向左移动的格数,设置 nz-form-label 的 [nzPull] 属性
        /// </summary>
        public string LabelPull { get; set; }
        /// <summary>
        /// 标签栅格向右移动的格数,设置 nz-form-label 的 [nzPush] 属性
        /// </summary>
        public string LabelPush { get; set; }
        /// <summary>
        /// 标签Flex布局,设置 nz-form-label 的 [nzFlex] 属性
        /// </summary>
        public string LabelFlex { get; set; }
        /// <summary>
        /// 标签&lt;576px超窄尺寸响应式栅格,设置 nz-form-label 的 [nzXs] 属性,可以设置一个数字,相当于[nzXs]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string LabelXs { get; set; }
        /// <summary>
        /// 标签&lt;576px超窄尺寸响应式栅格占位格数，设置 nz-form-label 的 [nzXs] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzXs]="{span:6}"
        /// </summary>
        public int LabelXsSpan { get; set; }
        /// <summary>
        /// 标签&lt;576px超窄尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-label 的 [nzXs] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzXs]="{offset:6}"
        /// </summary>
        public int LabelXsOffset { get; set; }
        /// <summary>
        /// 标签&lt;576px超窄尺寸响应式栅格顺序,设置 nz-form-label 的 [nzXs] 属性,范例: 设置值为6,生成[nzXs]="{order:6}"
        /// </summary>
        public int LabelXsOrder { get; set; }
        /// <summary>
        /// 标签&lt;576px超窄尺寸响应式栅格向左移动的格数,设置 nz-form-label 的 [nzXs] 属性,范例: 设置值为6,生成[nzXs]="{pull:6}"
        /// </summary>
        public int LabelXsPull { get; set; }
        /// <summary>
        /// 标签&lt;576px超窄尺寸响应式栅格向右移动的格数,设置 nz-form-label 的 [nzXs] 属性,范例: 设置值为6,生成[nzXs]="{push:6}"
        /// </summary>
        public int LabelXsPush { get; set; }
        /// <summary>
        /// 标签≥576px窄尺寸响应式栅格,设置 nz-form-label 的 [nzSm] 属性,可以设置一个数字,相当于[nzSm]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string LabelSm { get; set; }
        /// <summary>
        /// 标签≥576px窄尺寸响应式栅格占位格数，设置 nz-form-label 的 [nzSm] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzSm]="{span:6}"
        /// </summary>
        public int LabelSmSpan { get; set; }
        /// <summary>
        /// 标签≥576px窄尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-label 的 [nzSm] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzSm]="{offset:6}"
        /// </summary>
        public int LabelSmOffset { get; set; }
        /// <summary>
        /// 标签≥576px窄尺寸响应式栅格顺序,设置 nz-form-label 的 [nzSm] 属性,范例: 设置值为6,生成[nzSm]="{order:6}"
        /// </summary>
        public int LabelSmOrder { get; set; }
        /// <summary>
        /// 标签≥576px窄尺寸响应式栅格向左移动的格数,设置 nz-form-label 的 [nzSm] 属性,范例: 设置值为6,生成[nzSm]="{pull:6}"
        /// </summary>
        public int LabelSmPull { get; set; }
        /// <summary>
        /// 标签≥576px窄尺寸响应式栅格向右移动的格数,设置 nz-form-label 的 [nzSm] 属性,范例: 设置值为6,生成[nzSm]="{push:6}"
        /// </summary>
        public int LabelSmPush { get; set; }
        /// <summary>
        /// 标签≥768px中尺寸响应式栅格,设置 nz-form-label 的 [nzMd] 属性,可以设置一个数字,相当于[nzMd]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string LabelMd { get; set; }
        /// <summary>
        /// 标签≥768px中尺寸响应式栅格占位格数，设置 nz-form-label 的 [nzMd] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzMd]="{span:6}"
        /// </summary>
        public int LabelMdSpan { get; set; }
        /// <summary>
        /// 标签≥768px中尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-label 的 [nzMd] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzMd]="{offset:6}"
        /// </summary>
        public int LabelMdOffset { get; set; }
        /// <summary>
        /// 标签≥768px中尺寸响应式栅格顺序,设置 nz-form-label 的 [nzMd] 属性,范例: 设置值为6,生成[nzMd]="{order:6}"
        /// </summary>
        public int LabelMdOrder { get; set; }
        /// <summary>
        /// 标签≥768px中尺寸响应式栅格向左移动的格数,设置 nz-form-label 的 [nzMd] 属性,范例: 设置值为6,生成[nzMd]="{pull:6}"
        /// </summary>
        public int LabelMdPull { get; set; }
        /// <summary>
        /// 标签≥768px中尺寸响应式栅格向右移动的格数,设置 nz-form-label 的 [nzMd] 属性,范例: 设置值为6,生成[nzMd]="{push:6}"
        /// </summary>
        public int LabelMdPush { get; set; }
        /// <summary>
        /// 标签≥992px宽尺寸响应式栅格,设置 nz-form-label 的 [nzLg] 属性,可以设置一个数字,相当于[nzLg]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string LabelLg { get; set; }
        /// <summary>
        /// 标签≥992px宽尺寸响应式栅格占位格数，设置 nz-form-label 的 [nzLg] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzLg]="{span:6}"
        /// </summary>
        public int LabelLgSpan { get; set; }
        /// <summary>
        /// 标签≥992px宽尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-label 的 [nzLg] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzLg]="{offset:6}"
        /// </summary>
        public int LabelLgOffset { get; set; }
        /// <summary>
        /// 标签≥992px宽尺寸响应式栅格顺序,设置 nz-form-label 的 [nzLg] 属性,范例: 设置值为6,生成[nzLg]="{order:6}"
        /// </summary>
        public int LabelLgOrder { get; set; }
        /// <summary>
        /// 标签≥992px宽尺寸响应式栅格向左移动的格数,设置 nz-form-label 的 [nzLg] 属性,范例: 设置值为6,生成[nzLg]="{pull:6}"
        /// </summary>
        public int LabelLgPull { get; set; }
        /// <summary>
        /// 标签≥992px宽尺寸响应式栅格向右移动的格数,设置 nz-form-label 的 [nzLg] 属性,范例: 设置值为6,生成[nzLg]="{push:6}"
        /// </summary>
        public int LabelLgPush { get; set; }
        /// <summary>
        /// 标签≥1200px超宽尺寸响应式栅格,设置 nz-form-label 的 [nzXl] 属性,可以设置一个数字,相当于[nzXl]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string LabelXl { get; set; }
        /// <summary>
        /// 标签≥1200px超宽尺寸响应式栅格占位格数，设置 nz-form-label 的 [nzXl] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzXl]="{span:6}"
        /// </summary>
        public int LabelXlSpan { get; set; }
        /// <summary>
        /// 标签≥1200px超宽尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-label 的 [nzXl] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzXl]="{offset:6}"
        /// </summary>
        public int LabelXlOffset { get; set; }
        /// <summary>
        /// 标签≥1200px超宽尺寸响应式栅格顺序,设置 nz-form-label 的 [nzXl] 属性,范例: 设置值为6,生成[nzXl]="{order:6}"
        /// </summary>
        public int LabelXlOrder { get; set; }
        /// <summary>
        /// 标签≥1200px超宽尺寸响应式栅格向左移动的格数,设置 nz-form-label 的 [nzXl] 属性,范例: 设置值为6,生成[nzXl]="{pull:6}"
        /// </summary>
        public int LabelXlPull { get; set; }
        /// <summary>
        /// 标签≥1200px超宽尺寸响应式栅格向右移动的格数,设置 nz-form-label 的 [nzXl] 属性,范例: 设置值为6,生成[nzXl]="{push:6}"
        /// </summary>
        public int LabelXlPush { get; set; }
        /// <summary>
        /// 标签≥1600px极宽尺寸响应式栅格,设置 nz-form-label 的 [nzXXl] 属性,可以设置一个数字,相当于[nzXXl]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string LabelXxl { get; set; }
        /// <summary>
        /// 标签≥1600px极宽尺寸响应式栅格占位格数，设置 nz-form-label 的 [nzXXl] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzXXl]="{span:6}"
        /// </summary>
        public int LabelXxlSpan { get; set; }
        /// <summary>
        /// 标签≥1600px极宽尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-label 的 [nzXXl] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzXXl]="{offset:6}"
        /// </summary>
        public int LabelXxlOffset { get; set; }
        /// <summary>
        /// 标签≥1600px极宽尺寸响应式栅格顺序,设置 nz-form-label 的 [nzXXl] 属性,范例: 设置值为6,生成[nzXXl]="{order:6}"
        /// </summary>
        public int LabelXxlOrder { get; set; }
        /// <summary>
        /// 标签≥1600px极宽尺寸响应式栅格向左移动的格数,设置 nz-form-label 的 [nzXXl] 属性,范例: 设置值为6,生成[nzXXl]="{pull:6}"
        /// </summary>
        public int LabelXxlPull { get; set; }
        /// <summary>
        /// 标签≥1600px极宽尺寸响应式栅格向右移动的格数,设置 nz-form-label 的 [nzXXl] 属性,范例: 设置值为6,生成[nzXXl]="{push:6}"
        /// </summary>
        public int LabelXxlPush { get; set; }
        /// <summary>
        /// 控件栅格占位格数,自动创建nz-form-control,nz-form-item容器标签,并设置 nz-form-control 的[nzSpan]属性,可选值: 0 - 24, 为 0 时隐藏
        /// </summary>
        public string ControlSpan { get; set; }
        /// <summary>
        /// 控件栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,自动创建nz-form-control,nz-form-item容器标签,并设置 nz-form-control 的 [nzOffset] 属性,范例: 设置值为4,将标签向右侧偏移4格宽度
        /// </summary>
        public string ControlOffset { get; set; }
        /// <summary>
        /// 控件栅格顺序,自动创建nz-form-control,nz-form-item容器标签,并设置 nz-form-control 的 [nzOrder] 属性
        /// </summary>
        public string ControlOrder { get; set; }
        /// <summary>
        /// 控件栅格向左移动的格数,自动创建nz-form-control,nz-form-item容器标签,并设置 nz-form-control 的 [nzPull] 属性
        /// </summary>
        public string ControlPull { get; set; }
        /// <summary>
        /// 控件栅格向右移动的格数,自动创建nz-form-control,nz-form-item容器标签,并设置 nz-form-control 的 [nzPush] 属性
        /// </summary>
        public string ControlPush { get; set; }
        /// <summary>
        /// 控件Flex布局,自动创建nz-form-control,nz-form-item容器标签,并设置 nz-form-control 的 [nzFlex] 属性
        /// </summary>
        public string ControlFlex { get; set; }
        /// <summary>
        /// 控件&lt;576px超窄尺寸响应式栅格,设置 nz-form-control 的 [nzXs] 属性,可以设置一个数字,相当于[nzXs]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string ControlXs { get; set; }
        /// <summary>
        /// 控件&lt;576px超窄尺寸响应式栅格占位格数，设置 nz-form-control 的 [nzXs] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzXs]="{span:6}"
        /// </summary>
        public int ControlXsSpan { get; set; }
        /// <summary>
        /// 控件&lt;576px超窄尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-control 的 [nzXs] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzXs]="{offset:6}"
        /// </summary>
        public int ControlXsOffset { get; set; }
        /// <summary>
        /// 控件&lt;576px超窄尺寸响应式栅格顺序,设置 nz-form-control 的 [nzXs] 属性,范例: 设置值为6,生成[nzXs]="{order:6}"
        /// </summary>
        public int ControlXsOrder { get; set; }
        /// <summary>
        /// 控件&lt;576px超窄尺寸响应式栅格向左移动的格数,设置 nz-form-control 的 [nzXs] 属性,范例: 设置值为6,生成[nzXs]="{pull:6}"
        /// </summary>
        public int ControlXsPull { get; set; }
        /// <summary>
        /// 控件&lt;576px超窄尺寸响应式栅格向右移动的格数,设置 nz-form-control 的 [nzXs] 属性,范例: 设置值为6,生成[nzXs]="{push:6}"
        /// </summary>
        public int ControlXsPush { get; set; }
        /// <summary>
        /// 控件≥576px窄尺寸响应式栅格,设置 nz-form-control 的 [nzSm] 属性,可以设置一个数字,相当于[nzSm]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string ControlSm { get; set; }
        /// <summary>
        /// 控件≥576px窄尺寸响应式栅格占位格数，设置 nz-form-control 的 [nzSm] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzSm]="{span:6}"
        /// </summary>
        public int ControlSmSpan { get; set; }
        /// <summary>
        /// 控件≥576px窄尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-control 的 [nzSm] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzSm]="{offset:6}"
        /// </summary>
        public int ControlSmOffset { get; set; }
        /// <summary>
        /// 控件≥576px窄尺寸响应式栅格顺序,设置 nz-form-control 的 [nzSm] 属性,范例: 设置值为6,生成[nzSm]="{order:6}"
        /// </summary>
        public int ControlSmOrder { get; set; }
        /// <summary>
        /// 控件≥576px窄尺寸响应式栅格向左移动的格数,设置 nz-form-control 的 [nzSm] 属性,范例: 设置值为6,生成[nzSm]="{pull:6}"
        /// </summary>
        public int ControlSmPull { get; set; }
        /// <summary>
        /// 控件≥576px窄尺寸响应式栅格向右移动的格数,设置 nz-form-control 的 [nzSm] 属性,范例: 设置值为6,生成[nzSm]="{push:6}"
        /// </summary>
        public int ControlSmPush { get; set; }
        /// <summary>
        /// 控件≥768px中尺寸响应式栅格,设置 nz-form-control 的 [nzMd] 属性,可以设置一个数字,相当于[nzMd]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string ControlMd { get; set; }
        /// <summary>
        /// 控件≥768px中尺寸响应式栅格占位格数，设置 nz-form-control 的 [nzMd] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzMd]="{span:6}"
        /// </summary>
        public int ControlMdSpan { get; set; }
        /// <summary>
        /// 控件≥768px中尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-control 的 [nzMd] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzMd]="{offset:6}"
        /// </summary>
        public int ControlMdOffset { get; set; }
        /// <summary>
        /// 控件≥768px中尺寸响应式栅格顺序,设置 nz-form-control 的 [nzMd] 属性,范例: 设置值为6,生成[nzMd]="{order:6}"
        /// </summary>
        public int ControlMdOrder { get; set; }
        /// <summary>
        /// 控件≥768px中尺寸响应式栅格向左移动的格数,设置 nz-form-control 的 [nzMd] 属性,范例: 设置值为6,生成[nzMd]="{pull:6}"
        /// </summary>
        public int ControlMdPull { get; set; }
        /// <summary>
        /// 控件≥768px中尺寸响应式栅格向右移动的格数,设置 nz-form-control 的 [nzMd] 属性,范例: 设置值为6,生成[nzMd]="{push:6}"
        /// </summary>
        public int ControlMdPush { get; set; }
        /// <summary>
        /// 控件≥992px宽尺寸响应式栅格,设置 nz-form-control 的 [nzLg] 属性,可以设置一个数字,相当于[nzLg]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string ControlLg { get; set; }
        /// <summary>
        /// 控件≥992px宽尺寸响应式栅格占位格数，设置 nz-form-control 的 [nzLg] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzLg]="{span:6}"
        /// </summary>
        public int ControlLgSpan { get; set; }
        /// <summary>
        /// 控件≥992px宽尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-control 的 [nzLg] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzLg]="{offset:6}"
        /// </summary>
        public int ControlLgOffset { get; set; }
        /// <summary>
        /// 控件≥992px宽尺寸响应式栅格顺序,设置 nz-form-control 的 [nzLg] 属性,范例: 设置值为6,生成[nzLg]="{order:6}"
        /// </summary>
        public int ControlLgOrder { get; set; }
        /// <summary>
        /// 控件≥992px宽尺寸响应式栅格向左移动的格数,设置 nz-form-control 的 [nzLg] 属性,范例: 设置值为6,生成[nzLg]="{pull:6}"
        /// </summary>
        public int ControlLgPull { get; set; }
        /// <summary>
        /// 控件≥992px宽尺寸响应式栅格向右移动的格数,设置 nz-form-control 的 [nzLg] 属性,范例: 设置值为6,生成[nzLg]="{push:6}"
        /// </summary>
        public int ControlLgPush { get; set; }
        /// <summary>
        /// 控件≥1200px超宽尺寸响应式栅格,设置 nz-form-control 的 [nzXl] 属性,可以设置一个数字,相当于[nzXl]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string ControlXl { get; set; }
        /// <summary>
        /// 控件≥1200px超宽尺寸响应式栅格占位格数，设置 nz-form-control 的 [nzXl] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzXl]="{span:6}"
        /// </summary>
        public int ControlXlSpan { get; set; }
        /// <summary>
        /// 控件≥1200px超宽尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-control 的 [nzXl] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzXl]="{offset:6}"
        /// </summary>
        public int ControlXlOffset { get; set; }
        /// <summary>
        /// 控件≥1200px超宽尺寸响应式栅格顺序,设置 nz-form-control 的 [nzXl] 属性,范例: 设置值为6,生成[nzXl]="{order:6}"
        /// </summary>
        public int ControlXlOrder { get; set; }
        /// <summary>
        /// 控件≥1200px超宽尺寸响应式栅格向左移动的格数,设置 nz-form-control 的 [nzXl] 属性,范例: 设置值为6,生成[nzXl]="{pull:6}"
        /// </summary>
        public int ControlXlPull { get; set; }
        /// <summary>
        /// 控件≥1200px超宽尺寸响应式栅格向右移动的格数,设置 nz-form-control 的 [nzXl] 属性,范例: 设置值为6,生成[nzXl]="{push:6}"
        /// </summary>
        public int ControlXlPush { get; set; }
        /// <summary>
        /// 控件≥1600px极宽尺寸响应式栅格,设置 nz-form-control 的 [nzXXl] 属性,可以设置一个数字,相当于[nzXXl]="{span:数字}",也可以设置为对象,范例:{span:5,offset:1}
        /// </summary>
        public string ControlXxl { get; set; }
        /// <summary>
        /// 控件≥1600px极宽尺寸响应式栅格占位格数，设置 nz-form-control 的 [nzXXl] 属性,可选值: 0 - 24, 为 0 时隐藏,范例:设置值为6,生成[nzXXl]="{span:6}"
        /// </summary>
        public int ControlXxlSpan { get; set; }
        /// <summary>
        /// 控件≥1600px极宽尺寸响应式栅格向右偏移的格数,即栅格左侧的间隔格数，间隔内不可以有栅格,设置 nz-form-control 的 [nzXXl] 属性,范例: 设置值为6,将元素向右侧偏移了6格宽度,生成[nzXXl]="{offset:6}"
        /// </summary>
        public int ControlXxlOffset { get; set; }
        /// <summary>
        /// 控件≥1600px极宽尺寸响应式栅格顺序,设置 nz-form-control 的 [nzXXl] 属性,范例: 设置值为6,生成[nzXXl]="{order:6}"
        /// </summary>
        public int ControlXxlOrder { get; set; }
        /// <summary>
        /// 控件≥1600px极宽尺寸响应式栅格向左移动的格数,设置 nz-form-control 的 [nzXXl] 属性,范例: 设置值为6,生成[nzXXl]="{pull:6}"
        /// </summary>
        public int ControlXxlPull { get; set; }
        /// <summary>
        /// 控件≥1600px极宽尺寸响应式栅格向右移动的格数,设置 nz-form-control 的 [nzXXl] 属性,范例: 设置值为6,生成[nzXXl]="{push:6}"
        /// </summary>
        public int ControlXxlPush { get; set; }
    }
}
