using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms.Builders;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 文件上传渲染器
    /// </summary>
    public class UploadRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化文件上传渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public UploadRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new UploadBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            ConfigContent( builder );
            ConfigId( builder );
            ConfigDataSource( builder );
            ConfigMultiple( builder );
            ConfigEvents( builder );
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private void ConfigDataSource( TagBuilder builder ) {
            builder.AddAttribute( "nzAction", _config.GetValue( UiConst.Url ) );
            builder.AddAttribute( "[nzAction]", _config.GetValue( AngularConst.BindUrl ) );
        }

        /// <summary>
        /// 配置多选
        /// </summary>
        private void ConfigMultiple( TagBuilder builder ) {
            builder.AddAttribute( "[nzMultiple]", _config.GetBoolValue( UiConst.Multiple ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
        }
    }
}
