using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Enums;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Tables.Configs;

namespace Util.Ui.Zorro.TreeTables {
    /// <summary>
    /// 树形表格列定义，行数据变量名为 row
    /// </summary>
    [HtmlTargetElement( "util-tree-table-column" )]
    public class ColumnTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格列定义
        /// </summary>
        public ColumnTagHelper() {
            _config = new Config();
        }

        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string Column { get; set; }
        /// <summary>
        /// 列类型
        /// </summary>
        public TreeTableColumnType Type { get; set; }
        /// <summary>
        /// 日期格式化字符串，格式说明：
        /// 1. 年 - yyyy
        /// 2. 月 - MM
        /// 3. 日 - dd
        /// 4. 时 - HH
        /// 5. 分 - mm
        /// 6. 秒 - ss
        /// 7. 毫秒 - SSS
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// 是否排序
        /// </summary>
        public bool Sort { get; set; }
        /// <summary>
        /// 宽度，默认单位：px，范例：100，表示100px，也可以使用百分比，范例：10%
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// 截断原始内容，并使用tooltip显示完整内容，设置截断后保留的长度,范例：原始内容为abcd,设置2，则显示 ab...
        /// </summary>
        public int Truncate { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            _config.Content = context.Content;
            return new Util.Ui.Zorro.TreeTables.Renders.ColumnRender( _config );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config.Load( context, output );
            ResolveExpression();
            SetShareConfig();
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        private void ResolveExpression() {
            if( _config.Contains( UiConst.For ) == false )
                return;
            var expression = _config.GetValue<ModelExpression>( UiConst.For );
            ColumnExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 设置共享配置
        /// </summary>
        private void SetShareConfig() {
            var shareConfig = _config.Context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
            if( shareConfig == null )
                return;
            AddColumn( shareConfig );
        }

        /// <summary>
        /// 添加列配置
        /// </summary>
        private void AddColumn( TableShareConfig config ) {
            var title = GetTitle();
            var column = _config.GetValue( UiConst.Column );
            var isSort = _config.GetValue<bool>( UiConst.Sort );
            if( isSort )
                config.IsSort = true;
            config.Columns.Add( new ColumnInfo( title, column ) {
                IsSort = isSort,
                Width = GetWidth()
            } );
        }

        /// <summary>
        /// 获取标题
        /// </summary>
        private string GetTitle() {
            return _config.GetValue( UiConst.Title );
        }

        /// <summary>
        /// 获取宽度
        /// </summary>
        private string GetWidth() {
            return _config.GetValue( UiConst.Width );
        }
    }
}