using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Descriptions.Builders;

namespace Util.Ui.Zorro.Descriptions.Renders {
    /// <summary>
    /// 描述列表渲染器
    /// </summary>
    public class DescriptionRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化描述列表渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DescriptionRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DescriptionBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigTitle( builder );
            ConfigShowBorder( builder );
            ConfigColumn( builder );
            ConfigSize( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigTitle( TagBuilder builder ) {
            builder.AddAttribute( "nzTitle", _config.GetValue( UiConst.Title ) );
        }

        /// <summary>
        /// 配置显示边框
        /// </summary>
        private void ConfigShowBorder( TagBuilder builder ) {
            builder.AddAttribute( "[nzBordered]", _config.GetBoolValue( UiConst.ShowBorder ) );
        }

        /// <summary>
        /// 配置列
        /// </summary>
        private void ConfigColumn( TagBuilder builder ) {
            builder.AddAttribute( "[nzColumn]", _config.GetValue( UiConst.Column ) );
        }

        /// <summary>
        /// 配置大小
        /// </summary>
        private void ConfigSize( TagBuilder builder ) {
            builder.AddAttribute( "nzSize", _config.GetValue<DescriptionSize?>( UiConst.Size )?.Description() );
        }
    }
}