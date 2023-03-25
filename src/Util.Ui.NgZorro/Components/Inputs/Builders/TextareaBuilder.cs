using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Inputs.Builders {
    /// <summary>
    /// 文本域标签生成器
    /// </summary>
    public class TextareaBuilder : FormControlBuilderBase<TextareaBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化文本域标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TextareaBuilder( Config config ) : base( config, "textarea" ) {
            base.Attribute( "nz-input" );
            _config = config;
        }

        /// <summary>
        /// 配置占位符
        /// </summary>
        public virtual TextareaBuilder Placeholder() {
            AttributeIfNotEmpty( "placeholder", _config.GetValue( UiConst.Placeholder ) );
            AttributeIfNotEmpty( "[placeholder]", _config.GetValue( AngularConst.BindPlaceholder ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public TextareaBuilder Disabled() {
            AttributeIfNotEmpty( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[disabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置只读
        /// </summary>
        public TextareaBuilder Readonly() {
            AttributeIfNotEmpty( "[readOnly]", _config.GetBoolValue( UiConst.Readonly ) );
            AttributeIfNotEmpty( "[readOnly]", _config.GetValue( AngularConst.BindReadonly ) );
            return this;
        }

        /// <summary>
        /// 配置行数
        /// </summary>
        public TextareaBuilder Rows() {
            AttributeIfNotEmpty( "rows", _config.GetValue( UiConst.Rows ) );
            AttributeIfNotEmpty( "[rows]", _config.GetValue( AngularConst.BindRows ) );
            return this;
        }

        /// <summary>
        /// 配置列数
        /// </summary>
        public TextareaBuilder Columns() {
            AttributeIfNotEmpty( "cols", _config.GetValue( UiConst.Columns ) );
            AttributeIfNotEmpty( "[cols]", _config.GetValue( AngularConst.BindColumns ) );
            return this;
        }

        /// <summary>
        /// 配置自适应内容高度
        /// </summary>
        public TextareaBuilder Autosize() {
            AttributeIfNotEmpty( "[nzAutosize]", _config.GetBoolValue( UiConst.Autosize ) );
            AttributeIfNotEmpty( "[nzAutosize]", _config.GetValue( AngularConst.BindAutosize ) );
            var model = new RowsModel { MinRows = _config.GetValue<int?>( UiConst.MinRows ), MaxRows = _config.GetValue<int?>( UiConst.MaxRows ) };
            AttributeIfNotEmpty( "[nzAutosize]", model.ToJson() );
            return this;
        }

        /// <summary>
        /// 配置输入框大小
        /// </summary>
        public TextareaBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置必填项验证
        /// </summary>
        public override TextareaBuilder Required() {
            AttributeIfNotEmpty( "[x-required-extend]", _config.GetValue( UiConst.Required ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TextareaBuilder Events() {
            AttributeIfNotEmpty( "(input)", _config.GetValue( UiConst.OnInput ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Name().Placeholder().Disabled().Readonly().Size().Rows().Columns()
                .Autosize().Size().Events()
                .Required().RequiredMessage()
                .MinLength().MinLengthMessage()
                .MaxLength()
                .ValidationExtend();
        }
    }
}