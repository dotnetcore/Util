using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Directives.Tooltips;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Icons.Builders {
    /// <summary>
    /// 图标标签生成器
    /// </summary>
    public class IconBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化图标标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public IconBuilder( Config config ) : base( config, "i" ) {
            base.Attribute( "nz-icon" );
            _config = config;
        }

        /// <summary>
        /// 配置图标
        /// </summary>
        public IconBuilder Icon() {
            AttributeIfNotEmpty( "nzType", _config.GetValue<AntDesignIcon?>( UiConst.Icon )?.Description() );
            return this;
        }
        
        /// <summary>
        /// 配置图标类型
        /// </summary>
        public IconBuilder Type() {
            return Type( _config.GetValue<AntDesignIcon?>( UiConst.Type ) )
                .BindType( _config.GetValue( AngularConst.BindType ) );
        }

        /// <summary>
        /// 配置图标类型
        /// </summary>
        public IconBuilder Type( AntDesignIcon? type ) {
            return Type( type?.Description() );
        }
        
        /// <summary>
        /// 配置图标类型
        /// </summary>
        public IconBuilder Type( string type ) {
            AttributeIfNotEmpty( "nzType", type );
            return this;
        }

        /// <summary>
        /// 配置图标类型
        /// </summary>
        public IconBuilder BindType( string type ) {
            AttributeIfNotEmpty( "[nzType]", type );
            return this;
        }

        /// <summary>
        /// 配置图标主题
        /// </summary>
        public IconBuilder Theme() {
            return Theme( _config.GetValue<IconTheme?>( UiConst.Theme ) )
                .BindTheme( _config.GetValue( AngularConst.BindTheme ) );
        }

        /// <summary>
        /// 配置图标主题
        /// </summary>
        /// <param name="theme">主题</param>
        public IconBuilder Theme( IconTheme? theme ) {
            return Theme( theme?.Description() );
        }
        
        /// <summary>
        /// 配置图标主题
        /// </summary>
        /// <param name="theme">主题</param>
        public IconBuilder Theme( string theme ) {
            AttributeIfNotEmpty( "nzTheme", theme );
            return this;
        }

        /// <summary>
        /// 配置图标主题
        /// </summary>
        /// <param name="theme">主题</param>
        public IconBuilder BindTheme( string theme ) {
            AttributeIfNotEmpty( "[nzTheme]", theme );
            return this;
        }

        /// <summary>
        /// 配置双色图标主题色
        /// </summary>
        public IconBuilder Color() {
            if( _config.Contains( AntDesignConst.TwotoneColor ) || _config.Contains( AntDesignConst.BindTwotoneColor ) )
                Attribute( "nzTheme", IconTheme.Twotone.Description() );
            AttributeIfNotEmpty( "nzTwotoneColor", _config.GetValue( AntDesignConst.TwotoneColor ) );
            AttributeIfNotEmpty( "[nzTwotoneColor]", _config.GetValue( AntDesignConst.BindTwotoneColor ) );
            return this;
        }

        /// <summary>
        /// 配置图标旋转
        /// </summary>
        public IconBuilder Spin() {
            AttributeIfNotEmpty( "[nzSpin]", _config.GetBoolValue( UiConst.Spin ) );
            AttributeIfNotEmpty( "[nzSpin]", _config.GetValue( AngularConst.BindSpin ) );
            return this;
        }

        /// <summary>
        /// 配置旋转
        /// </summary>
        public IconBuilder Rotate() {
            AttributeIfNotEmpty( "[nzRotate]", _config.GetValue( UiConst.Rotate ) );
            AttributeIfNotEmpty( "[nzRotate]", _config.GetValue( AngularConst.BindRotate ) );
            return this;
        }

        /// <summary>
        /// 配置Iconfont图标
        /// </summary>
        public IconBuilder IconFont() {
            AttributeIfNotEmpty( "nzIconfont", _config.GetValue( AntDesignConst.IconFont ) );
            AttributeIfNotEmpty( "[nzIconfont]", _config.GetValue( AntDesignConst.BindIconFont ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public IconBuilder Events() {
            this.OnClick( _config );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            this.Tooltip( _config );
            Type().Theme().Color().Spin().Rotate().IconFont().Events();
        }
    }
}
