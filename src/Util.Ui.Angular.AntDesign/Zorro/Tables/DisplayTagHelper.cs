using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Tables.Configs;
using Util.Ui.Zorro.Tables.Renders;

namespace Util.Ui.Zorro.Tables {
    /// <summary>
    /// 表格编辑列显示内容
    /// </summary>
    [HtmlTargetElement( "util-table-column-display", ParentTag = "util-table-column" )]
    public class DisplayTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格列定义
        /// </summary>
        public DisplayTagHelper() {
            _config = new Config();
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DisplayRender( _config );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">上下文</param>
        protected override void ProcessBefore( Context context ) {
            _config.Load( context );
            SetColumnShareConfig();
        }

        /// <summary>
        /// 设置列共享配置
        /// </summary>
        private void SetColumnShareConfig() {
            var config = _config.GetValueFromItems<ColumnShareConfig>();
            if( config == null )
                return;
            config.IsCreateDisplay = false;
        }
    }
}
