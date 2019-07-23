using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Tags.Builders;

namespace Util.Ui.Zorro.Tags.Renders {
    /// <summary>
    /// 标签渲染器
    /// </summary>
    public class TagRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化标签渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TagRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ZorroTagBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigColor( builder );
            ConfigMode( builder );
            ConfigChecked( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        private void ConfigColor( TagBuilder builder ) {
            builder.AddAttribute( "nzColor", _config.GetValue<AntDesignColor?>( UiConst.ColorType )?.Description() );
            builder.AddAttribute( "nzColor", _config.GetValue( UiConst.Color ) );
            builder.AddAttribute( "[nzColor]", _config.GetValue( AngularConst.BindColor ) );
        }

        /// <summary>
        /// 配置模式
        /// </summary>
        private void ConfigMode( TagBuilder builder ) {
            builder.AddAttribute( "nzMode", _config.GetValue<TagMode?>( UiConst.Mode )?.Description() );
        }

        /// <summary>
        /// 配置选中状态
        /// </summary>
        private void ConfigChecked( TagBuilder builder ) {
            builder.AddAttribute( "[nzChecked]", _config.GetBoolValue( UiConst.Checked ) );
            builder.AddAttribute( "[(nzChecked)]", _config.GetBoolValue( AngularConst.BindOnChecked ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(nzAfterClose)", _config.GetValue( UiConst.OnAfterClose ) );
            builder.AddAttribute( "(nzOnClose)", _config.GetValue( UiConst.OnClose ) );
            builder.AddAttribute( "(nzCheckedChange)", _config.GetValue( UiConst.OnCheckedChange ) );
        }
    }
}