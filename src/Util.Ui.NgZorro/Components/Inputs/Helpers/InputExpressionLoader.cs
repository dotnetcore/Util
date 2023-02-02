using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Expressions;
using Util.Validation.Validators;

namespace Util.Ui.NgZorro.Components.Inputs.Helpers {
    /// <summary>
    /// 输入框表达式加载器
    /// </summary>
    public class InputExpressionLoader : NgZorroExpressionLoaderBase {
        /// <summary>
        /// 加载模型信息
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="info">模型表达式信息</param>
        protected override void Load( Config config, ModelExpressionInfo info ) {
            LoadLabel( config, info );
            LoadName( config, info );
            LoadNgModel( config, info );
            LoadMinRows( config, info );
            LoadVirtualHeight( config, info );
            LoadKeys( config, info );
            LoadPassword( config, info );
            LoadRequired( config, info );
            LoadMinLength( config, info );
            LoadMaxLength( config, info );
            LoadMin( config, info );
            LoadMax( config, info );
            LoadEmail( config, info );
            LoadRegex( config, info );
            LoadPhone( config, info );
            LoadIdCard( config, info );
        }

        /// <summary>
        /// 加载标签
        /// </summary>
        protected virtual void LoadLabel( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.LabelText, info.DisplayName, false );
        }

        /// <summary>
        /// 加载名称
        /// </summary>
        protected virtual void LoadName( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Name, info.LastPropertyName, false );
        }

        /// <summary>
        /// 加载模型绑定
        /// </summary>
        protected virtual void LoadNgModel( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( AngularConst.NgModel, info.SafePropertyName, false );
        }

        /// <summary>
        /// 加载文本域最小行数
        /// </summary>
        protected virtual void LoadMinRows( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.MinRows, 3, false );
        }

        /// <summary>
        /// 加载下拉树虚拟高度
        /// </summary>
        protected virtual void LoadVirtualHeight( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.VirtualHeight, "300px", false );
        }

        /// <summary>
        /// 加载下拉树标识列表
        /// </summary>
        protected virtual void LoadKeys( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.LoadKeys, info.SafePropertyName, false );
        }

        /// <summary>
        /// 加载密码类型
        /// </summary>
        protected virtual void LoadPassword( Config config, ModelExpressionInfo info ) {
	        if ( info.IsPassword == false )
		        return;
	        config.SetAttribute( UiConst.Type, "password", false );
        }

		/// <summary>
		/// 加载必填项验证
		/// </summary>
		protected virtual void LoadRequired( Config config, ModelExpressionInfo info ) {
            if ( info.IsRequired == false )
                return;
            config.SetAttribute( UiConst.Required, "true", false );
            config.SetAttribute( UiConst.RequiredMessage, info.RequiredMessage, false );
        }

        /// <summary>
        /// 加载最小长度验证
        /// </summary>
        protected virtual void LoadMinLength( Config config, ModelExpressionInfo info ) {
            if ( info.MinLength == null )
                return;
            config.SetAttribute( UiConst.MinLength, info.MinLength, false );
            config.SetAttribute( UiConst.MinLengthMessage, info.MinLengthMessage, false );
        }

        /// <summary>
        /// 加载最大长度验证
        /// </summary>
        protected virtual void LoadMaxLength( Config config, ModelExpressionInfo info ) {
            if ( info.MaxLength == null )
                return;
            config.SetAttribute( UiConst.MaxLength, info.MaxLength, false );
            config.SetAttribute( UiConst.MaxLengthMessage, info.MaxLengthMessage, false );
        }

        /// <summary>
        /// 加载最小值验证
        /// </summary>
        protected virtual void LoadMin( Config config, ModelExpressionInfo info ) {
            if ( info.Min == null )
                return;
            config.SetAttribute( UiConst.Min, info.Min, false );
            config.SetAttribute( UiConst.MinMessage, info.MinMessage, false );
        }

        /// <summary>
        /// 加载最大值验证
        /// </summary>
        protected virtual void LoadMax( Config config, ModelExpressionInfo info ) {
            if ( info.Max == null )
                return;
            config.SetAttribute( UiConst.Max, info.Max, false );
            config.SetAttribute( UiConst.MaxMessage, info.MaxMessage, false );
        }

        /// <summary>
        /// 加载电子邮件验证
        /// </summary>
        protected virtual void LoadEmail( Config config, ModelExpressionInfo info ) {
            if ( info.IsEmail == false )
                return;
            config.SetAttribute( UiConst.Type, InputType.Email, false );
            config.SetAttribute( UiConst.EmailMessage, info.EmailMessage, false );
        }

        /// <summary>
        /// 加载正则表达式验证
        /// </summary>
        protected virtual void LoadRegex( Config config, ModelExpressionInfo info ) {
            if ( info.IsRegularExpression == false )
                return;
            config.SetAttribute( UiConst.Pattern, info.Pattern, false );
            config.SetAttribute( UiConst.PatternMessage, info.RegularExpressionMessage, false );

        }
        /// <summary>
        /// 加载手机号验证
        /// </summary>
        protected virtual void LoadPhone( Config config, ModelExpressionInfo info ) {
            if ( info.IsPhone == false )
                return;
            config.SetAttribute( UiConst.IsInvalidPhone, true, false );
            config.SetAttribute( UiConst.Pattern, ValidatePattern.MobilePhonePattern, false );
            config.SetAttribute( UiConst.PatternMessage, info.PhoneMessage, false );
        }

        /// <summary>
        /// 加载身份证验证
        /// </summary>
        protected virtual void LoadIdCard( Config config, ModelExpressionInfo info ) {
            if ( info.IsIdCard == false )
                return;
            config.SetAttribute( UiConst.IsInvalidIdCard, true, false );
            config.SetAttribute( UiConst.Pattern, ValidatePattern.IdCardPattern, false );
            config.SetAttribute( UiConst.PatternMessage, info.IdCardMessage, false );
        }
    }
}
