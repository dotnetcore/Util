using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Templates.Builders;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Dividers.Builders {
    /// <summary>
    /// 分隔线标签生成器
    /// </summary>
    public class DividerBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化分隔线标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public DividerBuilder( Config config ) : base( config,"nz-divider" ) {
            _config = config;
        }

        /// <summary>
        /// 配置虚线
        /// </summary>
        public DividerBuilder Dashed() {
            AttributeIfNotEmpty( "[nzDashed]", _config.GetBoolValue( UiConst.Dashed ) );
            AttributeIfNotEmpty( "[nzDashed]", _config.GetValue( AngularConst.BindDashed ) );
            return this;
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        public DividerBuilder Type() {
            AttributeIfNotEmpty( "nzType", _config.GetValue<DividerType?>( UiConst.Type )?.Description() );
            AttributeIfNotEmpty( "[nzType]", _config.GetValue( AngularConst.BindType ) );
            return this;
        }

        /// <summary>
        /// 配置文字
        /// </summary>
        public DividerBuilder Text() {
            if ( _config.Content.IsEmpty() == false )
                return this;
            AttributeIfNotEmpty( "nzText", _config.GetValue( UiConst.Text ) );
            AttributeIfNotEmpty( "[nzText]", _config.GetValue( AngularConst.BindText ) );
            return this;
        }

        /// <summary>
        /// 配置文字方向
        /// </summary>
        public DividerBuilder Orientation() {
            AttributeIfNotEmpty( "nzOrientation", _config.GetValue<DividerOrientation?>( UiConst.Orientation )?.Description() );
            AttributeIfNotEmpty( "[nzOrientation]", _config.GetValue( AngularConst.BindOrientation ) );
            return this;
        }

        /// <summary>
        /// 配置正文样式
        /// </summary>
        public DividerBuilder Plain() {
            AttributeIfNotEmpty( "[nzPlain]", _config.GetBoolValue( UiConst.Plain ) );
            AttributeIfNotEmpty( "[nzPlain]", _config.GetValue( AngularConst.BindPlain ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Dashed().Type().Text().Orientation().Plain();
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( Config config ) {
            if ( config.Content.IsEmpty() )
                return;
            var id = $"m_{Util.Helpers.Id.Create()}";
            Attribute( "[nzText]", id );
            var templateBuilder = new TemplateBuilder( config );
            templateBuilder.Attribute( $"#{id}" );
            templateBuilder.AppendContent( config.Content );
            AppendContent( templateBuilder );
        }
    }
}