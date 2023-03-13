using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Cards.Builders {
    /// <summary>
    /// 卡片标签生成器
    /// </summary>
    public class CardBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化卡片标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public CardBuilder( Config config ) : base( config,"nz-card" ) {
            _config = config;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public CardBuilder Title() {
            SetTitle( _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 设置表单标签文本
        /// </summary>
        private void SetTitle( string value ) {
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                this.AttributeByI18n( "[nzTitle]", value );
                return;
            }
            AttributeIfNotEmpty( "nzTitle", value );
        }

        /// <summary>
        /// 配置操作组
        /// </summary>
        public CardBuilder Actions() {
            AttributeIfNotEmpty( "[nzActions]", _config.GetValue( UiConst.Actions ) );
            return this;
        }

        /// <summary>
        /// 配置内容区域自定义样式
        /// </summary>
        public CardBuilder BodyStyle() {
            AttributeIfNotEmpty( "[nzBodyStyle]", _config.GetValue( UiConst.BodyStyle ) );
            return this;
        }

        /// <summary>
        /// 配置是否移除边框
        /// </summary>
        public CardBuilder Borderless() {
            AttributeIfNotEmpty( "[nzBorderless]", _config.GetBoolValue( UiConst.Borderless ) );
            AttributeIfNotEmpty( "[nzBorderless]", _config.GetValue( AngularConst.BindBorderless ) );
            return this;
        }

        /// <summary>
        /// 配置封面
        /// </summary>
        public CardBuilder Cover() {
            AttributeIfNotEmpty( "[nzCover]", _config.GetValue( UiConst.Cover ) );
            return this;
        }

        /// <summary>
        /// 配置右上角操作区域
        /// </summary>
        public CardBuilder Extra() {
            AttributeIfNotEmpty( "[nzExtra]", _config.GetValue( UiConst.Extra ) );
            return this;
        }

        /// <summary>
        /// 配置鼠标滑过时是否可浮起
        /// </summary>
        public CardBuilder Hoverable() {
            AttributeIfNotEmpty( "[nzHoverable]", _config.GetBoolValue( UiConst.Hoverable ) );
            AttributeIfNotEmpty( "[nzHoverable]", _config.GetValue( AngularConst.BindHoverable ) );
            return this;
        }

        /// <summary>
        /// 配置是否加载状态
        /// </summary>
        public CardBuilder Loading() {
            AttributeIfNotEmpty( "[nzLoading]", _config.GetBoolValue( UiConst.Loading ) );
            AttributeIfNotEmpty( "[nzLoading]", _config.GetValue( AngularConst.BindLoading ) );
            return this;
        }

        /// <summary>
        /// 配置卡片类型
        /// </summary>
        public CardBuilder Type() {
            var type = _config.GetValue<CardType?>( UiConst.Type );
            if( type == CardType.Inner )
                Attribute( "nzType", "inner" );
            AttributeIfNotEmpty( "[nzType]", _config.GetValue( AngularConst.BindType ) );
            return this;
        }

        /// <summary>
        /// 配置卡片大小
        /// </summary>
        public CardBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<CardSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public CardBuilder Event() {
            this.OnClick( _config );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Title().Actions().BodyStyle().Borderless().Cover().Extra()
                .Hoverable().Loading().Type().Size()
                .Event();
        }
    }
}