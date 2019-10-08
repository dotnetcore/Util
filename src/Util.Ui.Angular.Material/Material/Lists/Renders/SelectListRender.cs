using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.Builders;

namespace Util.Ui.Material.Lists.Renders {
    /// <summary>
    /// 选择列表渲染器
    /// </summary>
    public class SelectListRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化选择列表渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SelectListRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SelectListBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigName( builder );
            ConfigDisabled( builder );
            ConfigModel( builder );
            ConfigEvents( builder );
            ConfigLabel( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置名称
        /// </summary>
        private void ConfigName( TagBuilder builder ) {
            builder.AddAttribute( "name", _config.GetValue( UiConst.Name ) );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.AddAttribute( "[(ngModel)]", _config.GetValue( UiConst.Model ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(ngModelChange)", _config.GetValue( UiConst.OnChange ) );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigLabel( TagBuilder builder ) {
            var title = _config.GetValue( UiConst.Label );
            if( string.IsNullOrWhiteSpace( title ) )
                return;
            var headerBuilder = new ListHeaderBuilder();
            headerBuilder.SetContent( title );
            builder.AppendContent( headerBuilder );
        }
    }
}