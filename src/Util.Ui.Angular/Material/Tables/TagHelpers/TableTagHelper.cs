using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Tables.Configs;
using Util.Ui.Material.Tables.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Tables.TagHelpers {
    /// <summary>
    /// 表格
    /// </summary>
    [HtmlTargetElement( "util-table" )]
    public class TableTagHelper : TagHelperBase {
        /// <summary>
        /// 查询参数
        /// </summary>
        public string QueryParam { get; set; }
        /// <summary>
        /// 基地址，基于该地址构建请求和删除地址，范例：传入test,则请求地址为/api/test,删除地址为/api/test/delete
        /// </summary>
        public string BaseUrl { get; set; }
        /// <summary>
        /// 排序列名
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public SortDirection SortDirection { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TableRender( new TableConfig( context ) );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            SetId( context );
            SetColumns( context );
        }

        /// <summary>
        /// 设置表格标识
        /// </summary>
        private void SetId( TagHelperContext context ) {
            if( context.AllAttributes.ContainsName( UiConst.Id ) ) {
                context.Items[MaterialConst.TableId] = context.AllAttributes[UiConst.Id];
                return;
            }
            context.Items[MaterialConst.TableId] = $"m_{Util.Helpers.Id.Guid()}";
        }

        /// <summary>
        /// 设置列集合
        /// </summary>
        private void SetColumns( TagHelperContext context ) {
            context.Items[UiConst.Columns] = new List<string>();
        }
    }
}