using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
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
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new AutocompleteRender( config );
        }
    }
}