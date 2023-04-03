using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Autocompletes.Helpers;
using Util.Ui.NgZorro.Components.Autocompletes.Renders;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Autocompletes {
    /// <summary>
    /// 自动完成,生成的标签为&lt;nz-autocomplete&gt;&lt;/nz-autocomplete&gt;
    /// </summary>
    [HtmlTargetElement( "util-autocomplete" )]
    public class AutocompleteTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 扩展属性,是否启用扩展指令,当设置Url或Data属性时自动启用,默认为 false
        /// </summary>
        public bool EnableExtend { get; set; }
        /// <summary>
        /// 扩展属性 [autoLoad],初始化时是否自动加载数据，默认为true,设置成false则手工加载
        /// </summary>
        public bool AutoLoad { get; set; }
        /// <summary>
        /// 扩展属性 [(queryParam)],查询参数
        /// </summary>
        public string QueryParam { get; set; }
        /// <summary>
        /// 扩展属性 order,排序条件,范例: creationTime desc
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 扩展属性 [order],排序条件,范例: creationTime desc
        /// </summary>
        public string BindSort { get; set; }
        /// <summary>
        /// 扩展属性 url,Api地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 扩展属性 [url],Api地址
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// 扩展属性 [data],数据源
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// [nzBackfill],使用键盘选择选项时，是否把当前高亮项的值即时回填到输入框中
        /// </summary>
        public bool Backfill { get; set; }
        /// <summary>
        /// [nzBackfill],使用键盘选择选项时，是否把当前高亮项的值即时回填到输入框中
        /// </summary>
        public string BindBackfill { get; set; }
        /// <summary>
        /// [nzDataSource],数据源
        /// </summary>
        public string Datasource { get; set; }
        /// <summary>
        /// [nzDefaultActiveFirstOption],是否默认高亮第一项
        /// </summary>
        public bool DefaultActiveFirstOption { get; set; }
        /// <summary>
        /// [nzDefaultActiveFirstOption],是否默认高亮第一项
        /// </summary>
        public string BindDefaultActiveFirstOption { get; set; }
        /// <summary>
        /// [nzWidth],宽度
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// [nzWidth],宽度
        /// </summary>
        public string BindWidth { get; set; }
        /// <summary>
        /// nzOverlayClassName,下拉根元素类名
        /// </summary>
        public string OverlayClassName { get; set; }
        /// <summary>
        /// [nzOverlayClassName],下拉根元素类名
        /// </summary>
        public string BindOverlayClassName { get; set; }
        /// <summary>
        /// nzOverlayStyle,下拉根元素样式
        /// </summary>
        public string OverlayStyle { get; set; }
        /// <summary>
        /// [nzOverlayStyle],下拉根元素样式
        /// </summary>
        public string BindOverlayStyle { get; set; }
        /// <summary>
        /// [compareWith],比较算法函数,函数定义:(o1: any, o2: any) => boolean
        /// </summary>
        public string CompareWith { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new AutocompleteService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new AutocompleteRender( _config );
        }
    }
}