using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Tables.Configs;
using Util.Ui.Zorro.Tables.Renders;

namespace Util.Ui.Zorro.Tables {
    /// <summary>
    /// 表格
    /// </summary>
    [HtmlTargetElement( "util-table" )]
    public class TableTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 基地址，基于该地址构建加载地址和删除地址，范例：传入test,则加载地址为/api/test,删除地址为/api/test/delete
        /// </summary>
        public string BaseUrl { get; set; }
        /// <summary>
        /// 基地址，基于该地址构建加载地址和删除地址，范例：传入test,则加载地址为/api/test,删除地址为/api/test/delete
        /// </summary>
        public string BindBaseUrl { get; set; }
        /// <summary>
        /// 数据加载地址，范例：/api/test
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 数据加载地址，范例：/api/test
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// 删除地址，注意：由于支持批量删除，所以采用Post提交，范例：/api/test/delete
        /// </summary>
        public string DeleteUrl { get; set; }
        /// <summary>
        /// 删除地址，注意：由于支持批量删除，所以采用Post提交，范例：/api/test/delete
        /// </summary>
        public string BindDeleteUrl { get; set; }
        /// <summary>
        /// 查询参数
        /// </summary>
        public string QueryParam { get; set; }
        /// <summary>
        /// 排序字段,范例: creationTime desc
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 最大高度
        /// </summary>
        public double MaxHeight { get; set; }
        /// <summary>
        /// 最小高度
        /// </summary>
        public double MinHeight { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// 初始化时是否自动加载数据，默认为true,设置成false则手工加载
        /// </summary>
        public bool AutoLoad { get; set; }
        /// <summary>
        /// [nzFrontPagination],是否在前端进行分页
        /// </summary>
        public bool FrontPage { get; set; }
        /// <summary>
        /// [nzShowSizeChanger],是否显示分页大小下拉框
        /// </summary>
        public bool ShowSizeChanger { get; set; }
        /// <summary>
        /// (nzPageSizeChange),分页大小变更事件
        /// </summary>
        public string OnPageSizeChange { get; set; }
        /// <summary>
        /// (nzPageIndexChange),页索引变更事件
        /// </summary>
        public string OnPageIndexChange { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            var config = new TableConfig( context );
            return new TableRender( config );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            InitShare( context );
        }

        /// <summary>
        /// 初始化共享实例
        /// </summary>
        public void InitShare( TagHelperContext context ) {
            context.SetValueToItems( TableConfig.TableShareKey, new TableShareConfig( GetId( context ) ) );
        }

        /// <summary>
        /// 设置表格标识
        /// </summary>
        private string GetId( TagHelperContext context ) {
            if ( context.AllAttributes.ContainsName( UiConst.Id ) )
                return context.GetValueFromAttributes<string>( UiConst.Id );
            return $"m_{Util.Helpers.Id.Guid()}";
        }
    }
}