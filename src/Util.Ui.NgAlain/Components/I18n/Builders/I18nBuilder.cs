using System.Text;
using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgAlain.Components.I18n.Builders {
    /// <summary>
    /// i18n多语言标签生成器
    /// </summary>
    public class I18nBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 初始化i18n多语言标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public I18nBuilder( Config config ) : base( config, "span" ) {
            _config = config;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ConfigInnerHtml();
        }

        /// <summary>
        /// 配置innerHTML属性
        /// </summary>
        private void ConfigInnerHtml() {
            var key = _config.GetValue( UiConst.Key );
            if ( key.IsEmpty() )
                return;
            Attribute( "[innerHTML]", $"'{key}'|i18n{GetParam()}" );
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        private string GetParam() {
            var result = new StringBuilder();
            var param = _config.GetValue( UiConst.Param );
            if ( param.IsEmpty() )
                return null;
            result.Append( ":" );
            if ( param.StartsWith( "{" ) == false )
                result.Append( "{" );
            result.Append( param );
            if ( param.EndsWith( "}" ) == false )
                result.Append( "}" );
            return result.ToString();
        }
    }
}