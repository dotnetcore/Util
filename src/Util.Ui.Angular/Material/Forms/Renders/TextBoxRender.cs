using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.Builders;
using Util.Ui.Material.Forms.Configs;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 文本框渲染器
    /// </summary>
    public class TextBoxRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly TextBoxConfig _config;

        /// <summary>
        /// 初始化文本框渲染器
        /// </summary>
        /// <param name="config">文本框配置</param>
        public TextBoxRender( TextBoxConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override ITagBuilder GetTagBuilder() {
            var builder = new TextBoxWrapperBuilder();
            base.Config( builder );
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TextBoxWrapperBuilder builder ) {
            ConfigType( builder );
            ConfigReadOnly( builder );
            ConfigShowClearButton( builder );
            ConfigValidations( builder );
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Type, _config.GetValue<TextBoxType?>( UiConst.Type )?.Description() );
        }

        /// <summary>
        /// 配置只读
        /// </summary>
        private void ConfigReadOnly( TagBuilder builder ) {
            builder.AddAttribute( "[readonly]", _config.GetBoolValue( UiConst.ReadOnly ) );
        }

        /// <summary>
        /// 配置是否显示清除按钮
        /// </summary>
        private void ConfigShowClearButton( TagBuilder builder ) {
            builder.AddAttribute( "[showClearButton]", _config.GetBoolValue( MaterialConst.ShowClearButton ) );
        }

        /// <summary>
        /// 配置验证操作
        /// </summary>
        private void ConfigValidations( TextBoxWrapperBuilder builder ) {
            ConfigEmail( builder );
            ConfigMinLength( builder );
            ConfigMaxLength( builder );
        }

        /// <summary>
        /// 配置Email验证
        /// </summary>
        private void ConfigEmail( TagBuilder builder ) {
            builder.AddAttribute( "emailMessage", _config.GetValue( UiConst.EmailMessage ) );
        }

        /// <summary>
        /// 配置最小长度验证
        /// </summary>
        private void ConfigMinLength( TextBoxWrapperBuilder builder ) {
            builder.AddAttribute( "[minLength]", _config.GetValue( UiConst.MinLength ) );
            builder.AddAttribute( "minLengthMessage", _config.GetValue( UiConst.MinLengthMessage ) );
        }

        /// <summary>
        /// 配置最大长度验证
        /// </summary>
        private void ConfigMaxLength( TextBoxWrapperBuilder builder ) {
            builder.AddAttribute( "[maxLength]", _config.GetValue( UiConst.MaxLength ) );
        }
    }
}
