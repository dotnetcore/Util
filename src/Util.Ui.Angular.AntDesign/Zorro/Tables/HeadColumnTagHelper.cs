using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Enums;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Tables.Configs;
using Util.Ui.Zorro.Tables.Renders;

namespace Util.Ui.Zorro.Tables {
    /// <summary>
    /// 表格标题列定义
    /// </summary>
    [HtmlTargetElement( "util-table-head-column" )]
    public class HeadColumnTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格标题列定义
        /// </summary>
        public HeadColumnTagHelper() {
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
        /// 表格列类型
        /// </summary>
        public TableColumnType Type { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 宽度，默认单位：px，范例：100，表示100px，也可以使用百分比，范例：10%
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// 列合并
        /// </summary>
        public string Colspan { get; set; }
        /// <summary>
        /// 行合并
        /// </summary>
        public string Rowspan { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new HeadColumnRender( _config );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">上下文</param>
        protected override void ProcessBefore( Context context ) {
            _config.Load( context );
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
            var shareConfig = _config.GetValueFromItems<TableShareConfig>();
            if ( shareConfig == null )
                return;
            SetAutoCreateSort( shareConfig );
        }

        /// <summary>
        /// 设置自动创建排序列
        /// </summary>
        private void SetAutoCreateSort( TableShareConfig config ) {
            if( _config.GetValueFromAttributes<string>( UiConst.Sort ).IsEmpty() )
                return;
            config.AutoCreateSort = false;
            config.IsSort = true;
        }
    }
}