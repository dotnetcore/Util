using Util.Helpers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Forms.Builders;
using Util.Ui.Material.Forms.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 文本框渲染器
    /// </summary>
    public class TextBoxRender : RenderBase {
        /// <summary>
        /// 引用Id
        /// </summary>
        private string _refrenceId;
        /// <summary>
        /// 配置
        /// </summary>
        private readonly TextBoxConfig _config;

        /// <summary>
        /// 初始化文本框渲染器
        /// </summary>
        /// <param name="config">文本框配置</param>
        public TextBoxRender( TextBoxConfig config ) : base( config ){
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override ITagBuilder GetTagBuilder() {
            var formFieldBuilder = new FormFieldBuilder();
            var inputBuilder = new InputBuilder();
            formFieldBuilder.AppendChild( inputBuilder );
            InitInputBuilder( formFieldBuilder, inputBuilder );
            return formFieldBuilder;
        }

        /// <summary>
        /// 初始化输入控件生成器
        /// </summary>
        private void InitInputBuilder( FormFieldBuilder formFieldBuilder, InputBuilder inputBuilder ) {
            inputBuilder.SetText();
            inputBuilder.AddOtherAttributes( _config );
            inputBuilder.Id( _config );
            inputBuilder.AddAttribute( "name", _config.Name );
            inputBuilder.AddAttribute( "placeholder", _config.GetValue( UiConst.Placeholder ) );
            inputBuilder.AddAttribute( "value", _config.Value );
            inputBuilder.AddAttribute( "type", _config.Type );
            inputBuilder.AddAttribute( "[(ngModel)]", _config.GetValue( UiConst.Model ) );
            AddValidations( formFieldBuilder, inputBuilder );
        }

        /// <summary>
        /// 添加验证操作
        /// </summary>
        private void AddValidations( FormFieldBuilder formFieldBuilder, InputBuilder inputBuilder ) {
            AddRequired( formFieldBuilder, inputBuilder );
            AddMinLength( formFieldBuilder, inputBuilder );
        }

        /// <summary>
        /// 添加必填项验证
        /// </summary>
        private void AddRequired( FormFieldBuilder formFieldBuilder, InputBuilder inputBuilder ) {
            if( _config.Contains( UiConst.Required ) == false )
                return;
            inputBuilder.AddAttribute( UiConst.Required, "true" );
            AddError( formFieldBuilder, inputBuilder, UiConst.Required, _config.GetValue( UiConst.RequiredMessage ) );
        }

        /// <summary>
        /// 添加错误消息
        /// </summary>
        private void AddError( FormFieldBuilder formFieldBuilder, InputBuilder inputBuilder, string type, string message ) {
            if( string.IsNullOrWhiteSpace( message ) )
                return;
            AddRefrenceId( inputBuilder );
            formFieldBuilder.AppendChild( new ErrorBuilder( _refrenceId, type, message ) );
        }

        /// <summary>
        /// 添加引用Id
        /// </summary>
        private void AddRefrenceId( InputBuilder inputBuilder ) {
            if ( _refrenceId != null )
                return;
            _refrenceId = $"m_{Id.Guid()}";
            inputBuilder.AddAttribute( $"#{_refrenceId}", "ngModel" );
        }

        /// <summary>
        /// 添加最小长度验证
        /// </summary>
        private void AddMinLength( FormFieldBuilder formFieldBuilder, InputBuilder inputBuilder ) {
            if( _config.MinLength <= 0 )
                return;
            inputBuilder.AddAttribute( "minlength", _config.MinLength.ToString() );
            AddError( formFieldBuilder, inputBuilder, "minlength", _config.MinLengthMessage );
        }
    }
}
