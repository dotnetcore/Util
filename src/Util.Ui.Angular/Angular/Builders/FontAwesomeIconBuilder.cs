using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;

namespace Util.Ui.Angular.Builders {
    /// <summary>
    /// FontAwesome图标生成器
    /// </summary>
    public class FontAwesomeIconBuilder : TagBuilder {
        /// <summary>
        /// 初始化FontAwesome图标生成器
        /// </summary>
        public FontAwesomeIconBuilder() : base( "i" ) {
        }

        /// <summary>
        /// 设置图标
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="key">键</param>
        public void SetIcon( IConfig config, string key = "" ) {
            if( key.IsEmpty() )
                key = UiConst.FontAwesomeIcon;
            Class( config.GetValue<FontAwesomeIcon?>( key ).GetIcon() );
        }

        /// <summary>
        /// 设置绑定图标
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="key">键</param>
        public void SetBindIcon( IConfig config, string key = "" ) {
            if( key.IsEmpty() )
                key = AngularConst.BindFontAwesomeIcon;
            var value = config.GetValue( key );
            if ( value.IsEmpty() )
                return;
            Class( $"fa {{{{{value}}}}}" );
        }

        /// <summary>
        /// 配置图标大小
        /// </summary>
        /// <param name="config">配置</param>
        public void SetSize( IConfig config ) {
            if( config.Contains( UiConst.Size ) )
                Class( config.GetValue<IconSize>( UiConst.Size ).Description() );
        }
    }
}
