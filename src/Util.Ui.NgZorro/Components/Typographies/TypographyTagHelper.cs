using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Typographies.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Typographies {
    /// <summary>
    /// 排版组件基类
    /// </summary>
    public abstract class TypographyTagHelper : TooltipTagHelperBase {
        /// <summary>
        /// [nzEditable],是否可编辑，需要配合 [nzContent] 使用
        /// </summary>
        public bool Editable { get; set; }
        /// <summary>
        /// [nzEditable],是否可编辑，需要配合 [nzContent] 使用
        /// </summary>
        public string BindEditable { get; set; }
        /// <summary>
        /// nzEditIcon,自定义编辑图标
        /// </summary>
        public AntDesignIcon EditIcon { get; set; }
        /// <summary>
        /// [nzEditIcon],自定义编辑图标
        /// </summary>
        public string BindEditIcon { get; set; }
        /// <summary>
        /// nzEditTooltip,编辑按钮提示信息
        /// </summary>
        public string EditTooltip { get; set; }
        /// <summary>
        /// [nzEditTooltip],编辑按钮提示信息,设置为null清除提示
        /// </summary>
        public string BindEditTooltip { get; set; }
        /// <summary>
        /// [nzCopyable],是否可复制，需要配合 [nzContent] 使用
        /// </summary>
        public bool Copyable { get; set; }
        /// <summary>
        /// [nzCopyable],是否可复制，需要配合 [nzContent] 使用
        /// </summary>
        public string BindCopyable { get; set; }
        /// <summary>
        /// nzCopyText,自定义被复制的文本
        /// </summary>
        public string CopyText { get; set; }
        /// <summary>
        /// [nzCopyText],自定义被复制的文本
        /// </summary>
        public string BindCopyText { get; set; }
        /// <summary>
        /// [nzCopyIcons],自定义复制图标,默认值:['copy', 'check']
        /// </summary>
        public string CopyIcons { get; set; }
        /// <summary>
        /// [nzCopyIcons],自定义复制图标,将默认值 ['copy','check'] 中的 copy 图标替换为自定义图标
        /// </summary>
        public AntDesignIcon CopyIcon { get; set; }
        /// <summary>
        /// [nzCopyTooltips],自定义复制提示,设置为null清除提示,范例:['复制', '已复制']
        /// </summary>
        public string CopyTooltips { get; set; }
        /// <summary>
        /// nzType,文本类型
        /// </summary>
        public TextType Type { get; set; }
        /// <summary>
        /// [nzType],文本类型
        /// </summary>
        public string BindType { get; set; }
        /// <summary>
        /// [nzDisabled],禁用文本
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],禁用文本
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzEllipsis],自动溢出省略，动态内容时需要配合 [nzContent] 使用
        /// </summary>
        public bool Ellipsis { get; set; }
        /// <summary>
        /// [nzEllipsis],自动溢出省略，动态内容时需要配合 [nzContent] 使用
        /// </summary>
        public string BindEllipsis { get; set; }
        /// <summary>
        /// [nzExpandable],自动溢出省略时是否可展开
        /// </summary>
        public bool Expandable { get; set; }
        /// <summary>
        /// [nzExpandable],自动溢出省略时是否可展开
        /// </summary>
        public string BindExpandable { get; set; }
        /// <summary>
        /// [nzEllipsisRows],自动溢出省略时省略行数
        /// </summary>
        public int EllipsisRows { get; set; }
        /// <summary>
        /// [nzEllipsisRows],自动溢出省略时省略行数
        /// </summary>
        public string BindEllipsisRows { get; set; }
        /// <summary>
        /// nzSuffix,自动溢出省略时的文本后缀
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// [nzSuffix],自动溢出省略时的文本后缀
        /// </summary>
        public string BindSuffix { get; set; }
        /// <summary>
        /// nzContent,内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// [nzContent],内容
        /// </summary>
        public string BindContent { get; set; }
        /// <summary>
        /// [(nzContent)],内容
        /// </summary>
        public string BindonContent { get; set; }
        /// <summary>
        /// (nzContentChange),当用户提交编辑内容时触发
        /// </summary>
        public string OnContentChange { get; set; }
        /// <summary>
        /// (nzExpandChange),当展开省略文本时触发
        /// </summary>
        public string OnExpandChange { get; set; }
        /// <summary>
        /// (nzOnEllipsis),当省略状态变化时触发
        /// </summary>
        public string OnEllipsis { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TypographyRender( config, GetTagBuilder() );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected abstract TagBuilder GetTagBuilder();
    }
}
