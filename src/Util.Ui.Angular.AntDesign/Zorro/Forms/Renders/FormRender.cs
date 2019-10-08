using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 表单渲染器
    /// </summary>
    public class FormRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            builder.AddAttribute( "nz-form" );
            ConfigId( builder );
            ConfigAutoComplete( builder );
            ConfigLayout( builder );
            ConfigLabel( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            if( _config.Contains( UiConst.Id ) )
                builder.AddAttribute( $"#{_config.GetValue( UiConst.Id )}", "ngForm" );
        }

        /// <summary>
        /// 配置自动完成
        /// </summary>
        private void ConfigAutoComplete( TagBuilder builder ) {
            var isAutoComplete = _config.GetValue<bool?>( UiConst.AutoComplete );
            if ( isAutoComplete == true ) {
                builder.AddAttribute( "autocomplete", "on" );
                return;
            }
            builder.AddAttribute( "autocomplete", "off" );
        }

        /// <summary>
        /// 配置布局方式
        /// </summary>
        private void ConfigLayout( TagBuilder builder ) {
            builder.AddAttribute( "nzLayout", _config.GetValue<FormLayout?>( UiConst.Layout )?.Description() );
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        private void ConfigLabel( TagBuilder builder ) {
            builder.AddAttribute( "[nzNoColon]", ( !_config.GetValue<bool?>( UiConst.ShowColon ) ).SafeString().ToLower() );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(ngSubmit)", _config.GetValue( UiConst.OnSubmit ) );
        }
    }
}
