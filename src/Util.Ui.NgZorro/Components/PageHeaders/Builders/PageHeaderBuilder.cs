using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.PageHeaders.Builders {
    /// <summary>
    /// 页头标签生成器
    /// </summary>
    public class PageHeaderBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 初始化页头标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public PageHeaderBuilder( Config config ) : base( config,"nz-page-header" ) {
            _config = config;
        }

        /// <summary>
        /// 配置透明背景
        /// </summary>
        public PageHeaderBuilder Ghost() {
            AttributeIfNotEmpty( "[nzGhost]", _config.GetBoolValue( UiConst.Ghost ) );
            AttributeIfNotEmpty( "[nzGhost]", _config.GetValue( AngularConst.BindGhost ) );
            return this;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public PageHeaderBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置子标题
        /// </summary>
        public PageHeaderBuilder Subtitle() {
            AttributeIfNotEmpty( "nzSubtitle", _config.GetValue( UiConst.Subtitle ) );
            AttributeIfNotEmpty( "[nzSubtitle]", _config.GetValue( AngularConst.BindSubtitle ) );
            return this;
        }

        /// <summary>
        /// 配置显示返回按钮
        /// </summary>
        public PageHeaderBuilder ShowBack() {
            if ( _config.Contains( UiConst.BackIcon ) )
                return this;
            if ( _config.Contains( AngularConst.BindBackIcon ) )
                return this;
            if ( _config.GetValue<bool?>( UiConst.ShowBack ) == true )
                Attribute( "nzBackIcon" );
            return this;
        }

        /// <summary>
        /// 配置返回按钮图标
        /// </summary>
        public PageHeaderBuilder BackIcon() {
            AttributeIfNotEmpty( "nzBackIcon", _config.GetValue<AntDesignIcon?>( UiConst.BackIcon )?.Description() );
            AttributeIfNotEmpty( "[nzBackIcon]", _config.GetValue( AngularConst.BindBackIcon ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public PageHeaderBuilder Events() {
            AttributeIfNotEmpty( "(nzBack)", _config.GetValue( UiConst.OnBack ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Ghost().Title().Subtitle().ShowBack().BackIcon().Events();
        }
    }
}