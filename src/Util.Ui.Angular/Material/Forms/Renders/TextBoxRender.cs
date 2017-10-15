using Util.Helpers;
using Util.Ui.Builders;
using Util.Ui.Material.Forms.Builders;
using Util.Ui.Material.Forms.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 文本框渲染器
    /// </summary>
    public class TextBoxRender : RenderBase<FormFieldBuilder, TextBoxConfig> {
        /// <summary>
        /// 初始化文本框渲染器
        /// </summary>
        /// <param name="config">文本框配置</param>
        public TextBoxRender( TextBoxConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override FormFieldBuilder GetTagBuilder() {
            return new FormFieldBuilder();
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="formFieldBuilder">标签生成器</param>
        /// <param name="config">组件配置</param>
        protected override void Render( FormFieldBuilder formFieldBuilder, TextBoxConfig config ) {
            var inputBuilder = new InputBuilder();
            formFieldBuilder.AppendChild( inputBuilder );
            InitInputBuilder( formFieldBuilder, inputBuilder, config );
        }

        /// <summary>
        /// 初始化输入控件生成器
        /// </summary>
        private void InitInputBuilder( FormFieldBuilder formFieldBuilder, InputBuilder inputBuilder, TextBoxConfig config ) {
            inputBuilder.SetText();
            foreach( var attribute in config.GetAttributes() ) {
                inputBuilder.Attribute( attribute.Key, attribute.Value );
            }
            inputBuilder.AddAttribute( "name", config.Name );
            inputBuilder.AddAttribute( "placeholder", config.Placeholder );
            inputBuilder.AddAttribute( "value", config.Value );
            inputBuilder.AddAttribute( "type", config.Type );
            inputBuilder.AddAttribute( "[(ngModel)]", config.Model );
            AddValidations( formFieldBuilder, inputBuilder, config );
        }

        /// <summary>
        /// 添加验证操作
        /// </summary>
        private void AddValidations( FormFieldBuilder formFieldBuilder, InputBuilder inputBuilder, TextBoxConfig config ) {
            AddRequired( formFieldBuilder, inputBuilder, config );
            AddMinLength( formFieldBuilder, inputBuilder, config );
        }

        /// <summary>
        /// 添加必填项验证
        /// </summary>
        private void AddRequired( FormFieldBuilder formFieldBuilder, InputBuilder inputBuilder, TextBoxConfig config ) {
            if( config.Required == false )
                return;
            inputBuilder.AddAttribute( "required", "true" );
            AddError( formFieldBuilder, inputBuilder, "required", config.RequiredMessage );
        }

        /// <summary>
        /// 添加错误消息
        /// </summary>
        private void AddError( FormFieldBuilder formFieldBuilder, InputBuilder inputBuilder, string type, string message ) {
            if( string.IsNullOrWhiteSpace( message ) )
                return;
            var id = $"m_{Id.Guid()}";
            inputBuilder.AddAttribute( $"#{id}", "ngModel" );
            formFieldBuilder.AppendChild( new ErrorBuilder( id, type, message ) );
        }

        /// <summary>
        /// 添加最小长度验证
        /// </summary>
        private void AddMinLength( FormFieldBuilder formFieldBuilder, InputBuilder inputBuilder, TextBoxConfig config ) {
            if( config.MinLength <= 0 )
                return;
            inputBuilder.AddAttribute( "minlength", config.MinLength.ToString() );
            AddError( formFieldBuilder, inputBuilder, "minlength", config.MinLengthMessage );
        }
    }
}
