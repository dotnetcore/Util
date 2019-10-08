using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Properties;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Enums;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Tables.Configs;
using Util.Ui.Zorro.Tables.Renders;

namespace Util.Ui.Zorro.Tables {
    /// <summary>
    /// 表格列定义，行数据变量名为 row，行索引变量名为 index
    /// </summary>
    [HtmlTargetElement( "util-table-column" )]
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
        /// 表格列类型
        /// </summary>
        public TableColumnType Type { get; set; }
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
        /// 是否编辑列，默认值：false
        /// </summary>
        public bool IsEdit { get; set; }
        /// <summary>
        /// 列合并，[attr.colspan]
        /// </summary>
        public string Colspan { get; set; }
        /// <summary>
        /// 行合并，[attr.rowspan]
        /// </summary>
        public string Rowspan { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ColumnRender( _config );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">上下文</param>
        protected override void ProcessBefore( Context context ) {
            _config.Load( context );
            ResolveExpression();
            var tableShareConfig = _config.GetValueFromItems<TableShareConfig>();
            var column = _config.GetValue( UiConst.Column );
            var columnShareConfig = new ColumnShareConfig( tableShareConfig, column );
            SetTableShareConfig( tableShareConfig, column );
            SetColumnShareConfig( columnShareConfig );
            ConfigEdit( tableShareConfig, columnShareConfig );
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
        /// 设置表格共享配置
        /// </summary>
        private void SetTableShareConfig( TableShareConfig config,string column ) {
            if( config == null )
                return;
            var type = _config.Context.GetValueFromAttributes<TableColumnType?>( UiConst.Type );
            AddColumn( config, type, column );
        }

        /// <summary>
        /// 添加列配置
        /// </summary>
        private void AddColumn( TableShareConfig config, TableColumnType? type, string column ) {
            var title = GetTitle( type );
            var isSort = _config.GetValue<bool>( UiConst.Sort );
            if( isSort )
                config.IsSort = true;
            config.Columns.Add( new ColumnInfo( title, column ) {
                IsSort = isSort,
                IsCheckbox = type == TableColumnType.Checkbox,
                IsLineNumber = type == TableColumnType.LineNumber,
                Width = GetWidth( type )
            } );
        }

        /// <summary>
        /// 获取标题
        /// </summary>
        private string GetTitle( TableColumnType? type ) {
            var result = _config.GetValue( UiConst.Title );
            if( result.IsEmpty() == false )
                return result;
            return type == TableColumnType.LineNumber ? R.LineNumber : null;
        }

        /// <summary>
        /// 获取宽度
        /// </summary>
        private string GetWidth( TableColumnType? type ) {
            var result = _config.GetValue( UiConst.Width );
            if( result.IsEmpty() == false )
                return result;
            if( type == TableColumnType.LineNumber )
                return TableConfig.LineNumberWidth;
            if( type == TableColumnType.Checkbox )
                return TableConfig.CheckboxWidth;
            return null;
        }

        /// <summary>
        /// 设置列共享配置
        /// </summary>
        private void SetColumnShareConfig( ColumnShareConfig config ) {
            _config.SetValueToItems( config );
        }

        /// <summary>
        /// 配置编辑模式
        /// </summary>
        private void ConfigEdit( TableShareConfig tableShareConfig, ColumnShareConfig columnShareConfig ) {
            var isEdit = _config.GetValue<bool>( UiConst.IsEdit );
            if ( !isEdit )
                return;
            columnShareConfig.IsEdit = true;
            if ( tableShareConfig == null )
                return;
            tableShareConfig.IsEdit = true;
        }
    }
}