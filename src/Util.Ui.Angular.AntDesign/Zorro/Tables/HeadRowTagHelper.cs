using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Tables.Configs;
using Util.Ui.Zorro.Tables.Renders;

namespace Util.Ui.Zorro.Tables {
    /// <summary>
    /// 表格标题行定义，该标签应放在 util-table-head 中
    /// </summary>
    [HtmlTargetElement( "util-table-head-row",ParentTag = "util-table-head" )]
    public class HeadRowTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格标题列定义
        /// </summary>
        public HeadRowTagHelper() {
            _config = new Config();
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new HeadRowRender( _config );
        }

        /// <summary>
        /// 处理前操作
        /// </summary>
        /// <param name="context">上下文</param>
        protected override void ProcessBefore( Context context ) {
            _config.Load( context );
            SetShareConfig();
        }

        /// <summary>
        /// 设置共享配置
        /// </summary>
        private void SetShareConfig() {
            var shareConfig = _config.GetValueFromItems<TableShareConfig>();
            if ( shareConfig == null )
                return;
            shareConfig.AutoCreateHeadRow = false;
        }
    }
}