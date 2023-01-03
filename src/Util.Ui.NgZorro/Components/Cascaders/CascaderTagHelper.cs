using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Cascaders.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Cascaders {
    /// <summary>
    /// 级联选择,生成的标签为&lt;nz-cascader&gt;&lt;/nz-cascader&gt;
    /// </summary>
    [HtmlTargetElement( "util-cascader" )]
    public class CascaderTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// [nzAllowClear],是否允许清除,默认值: true
        /// </summary>
        public bool AllowClear { get; set; }
        /// <summary>
        /// [nzAllowClear],是否允许清除,默认值: true
        /// </summary>
        public string BindAllowClear { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动聚焦，当存在输入框时
        /// </summary>
        public bool AutoFocus { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动聚焦，当存在输入框时
        /// </summary>
        public string BindAutoFocus { get; set; }
        /// <summary>
        /// [nzChangeOn],点击父级菜单项时，可通过该函数判断是否允许值的变化,函数定义: (option: any, index: number) => boolean
        /// </summary>
        public string ChangeOn { get; set; }
        /// <summary>
        /// [nzChangeOnSelect],点选每级菜单项时,是否值都会变化
        /// </summary>
        public bool ChangeOnSelect { get; set; }
        /// <summary>
        /// [nzChangeOnSelect],点选每级菜单项时,是否值都会变化
        /// </summary>
        public string BindChangeOnSelect { get; set; }
        /// <summary>
        /// nzColumnClassName,自定义浮层列类名
        /// </summary>
        public string ColumnClassName { get; set; }
        /// <summary>
        /// [nzColumnClassName],自定义浮层列类名
        /// </summary>
        public string BindColumnClassName { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// nzExpandIcon,自定义次级菜单展开图标
        /// </summary>
        public AntDesignIcon ExpandIcon { get; set; }
        /// <summary>
        /// [nzExpandIcon],自定义次级菜单展开图标
        /// </summary>
        public string BindExpandIcon { get; set; }
        /// <summary>
        /// nzExpandTrigger,次级菜单的展开方式
        /// </summary>
        public CascaderExpandTrigger ExpandTrigger { get; set; }
        /// <summary>
        /// [nzExpandTrigger],次级菜单的展开方式
        /// </summary>
        public string BindExpandTrigger { get; set; }
        /// <summary>
        /// nzLabelProperty,选项显示值的属性名
        /// </summary>
        public string LabelProperty { get; set; }
        /// <summary>
        /// [nzLabelProperty],选项显示值的属性名
        /// </summary>
        public string BindLabelProperty { get; set; }
        /// <summary>
        /// [nzLabelRender],选择后展示的渲染模板
        /// </summary>
        public string LabelRender { get; set; }
        /// <summary>
        /// [nzLoadData],动态加载选项函数,如果提供了ngModel初始值，且未提供nzOptions值，则会立即触发动态加载,函数定义: (option: any, index?: index) => PromiseLike&lt;any&gt;
        /// </summary>
        public string LoadData { get; set; }
        /// <summary>
        /// nzMenuClassName,自定义浮层类名
        /// </summary>
        public string MenuClassName { get; set; }
        /// <summary>
        /// [nzMenuClassName],自定义浮层类名
        /// </summary>
        public string BindMenuClassName { get; set; }
        /// <summary>
        /// nzMenuStyle,自定义浮层样式
        /// </summary>
        public string MenuStyle { get; set; }
        /// <summary>
        /// [nzMenuStyle],自定义浮层样式
        /// </summary>
        public string BindMenuStyle { get; set; }
        /// <summary>
        /// nzNotFoundContent,下拉列表为空时显示的内容
        /// </summary>
        public string NotFoundContent { get; set; }
        /// <summary>
        /// [nzNotFoundContent],下拉列表为空时显示的内容
        /// </summary>
        public string BindNotFoundContent { get; set; }
        /// <summary>
        /// [nzOptionRender],选项的渲染模板
        /// </summary>
        public string OptionRender { get; set; }
        /// <summary>
        /// [nzOptions],可选项数据源
        /// </summary>
        public string Options { get; set; }
        /// <summary>
        /// nzPlaceHolder,输入框占位文本
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [nzPlaceHolder],输入框占位文本
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// [nzShowArrow],是否显示箭头,默认值: true
        /// </summary>
        public bool ShowArrow { get; set; }
        /// <summary>
        /// [nzShowArrow],是否显示箭头,默认值: true
        /// </summary>
        public string BindShowArrow { get; set; }
        /// <summary>
        /// [nzShowInput],是否显示输入框,默认值: true
        /// </summary>
        public bool ShowInput { get; set; }
        /// <summary>
        /// [nzShowInput],是否显示输入框,默认值: true
        /// </summary>
        public string BindShowInput { get; set; }
        /// <summary>
        /// [nzShowSearch],是否支持搜索，默认情况下对 label 进行全匹配搜索，不能和 [nzLoadData] 同时使用
        /// </summary>
        public bool ShowSearch { get; set; }
        /// <summary>
        /// [nzShowSearch],是否支持搜索，默认情况下对 label 进行全匹配搜索，不能和 [nzLoadData] 同时使用
        /// </summary>
        public string BindShowSearch { get; set; }
        /// <summary>
        /// nzSize,输入框大小，可选值: 'large'|'small'|'default'
        /// </summary>
        public InputSize Size { get; set; }
        /// <summary>
        /// [nzSize],输入框大小，可选值: 'large'|'small'|'default'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// nzSuffixIcon,选择框后缀图标
        /// </summary>
        public AntDesignIcon SuffixIcon { get; set; }
        /// <summary>
        /// [nzSuffixIcon],选择框后缀图标
        /// </summary>
        public string BindSuffixIcon { get; set; }
        /// <summary>
        /// nzValueProperty,选项实际值的属性名,默认值: 'value'
        /// </summary>
        public string ValueProperty { get; set; }
        /// <summary>
        /// [nzValueProperty],选项实际值的属性名,默认值: 'value'
        /// </summary>
        public string BindValueProperty { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// (nzClear),清除事件,清除值时触发
        /// </summary>
        public string OnClear { get; set; }
        /// <summary>
        /// (nzVisibleChange),显示状态改变事件,菜单浮层显示/隐藏时触发
        /// </summary>
        public string OnVisibleChange { get; set; }
        /// <summary>
        /// (nzSelectionChange),选中状态改变事件,值发生变化时触发
        /// </summary>
        public string OnSelectionChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CascaderRender( config );
        }
    }
}