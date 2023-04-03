using Microsoft.AspNetCore.Mvc.Rendering;
using Util.Helpers;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Extensions;
using Config = Util.Ui.Configs.Config;

namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 表单控件标签生成器基类
    /// </summary>
    public abstract class FormControlBuilderBase<TBuilder> : AngularTagBuilder where TBuilder : FormControlBuilderBase<TBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表单项共享配置
        /// </summary>
        protected readonly FormItemShareConfig FormItemShareConfig;

        /// <summary>
        /// 初始化表单控件标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tagName">标签名称，范例：div</param>
        /// <param name="renderMode">渲染模式</param>
        protected FormControlBuilderBase( Config config, string tagName, TagRenderMode renderMode = TagRenderMode.Normal ) : base( config,tagName, renderMode ) {
            _config = config;
            FormItemShareConfig = GetShareConfig();
        }

        /// <summary>
        /// 获取表单项共享配置
        /// </summary>
        private FormItemShareConfig GetShareConfig() {
            return _config.GetValueFromItems<FormItemShareConfig>() ?? new FormItemShareConfig();
        }

        /// <summary>
        /// 配置名称
        /// </summary>
        public virtual TBuilder Name() {
            AttributeIfNotEmpty( "name", _config.GetValue( UiConst.Name ) );
            AttributeIfNotEmpty( "[name]", _config.GetValue( AngularConst.BindName ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        public virtual TBuilder NgModel() {
            this.NgModel( _config );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置表单控件
        /// </summary>
        public TBuilder FormControl() {
            AttributeIfNotEmpty( "[formControl]", _config.GetValue( UiConst.FormControl ) );
            AttributeIfNotEmpty( "formControlName", _config.GetValue( UiConst.FormControlName ) );
            AttributeIfNotEmpty( "[formControlName]", _config.GetValue( AngularConst.BindFormControlName ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置间距项
        /// </summary>
        public TBuilder SpaceItem() {
            this.SpaceItem( _config );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置模型变更事件
        /// </summary>
        public virtual TBuilder OnModelChange() {
            AttributeIfNotEmpty( "(ngModelChange)", _config.GetValue( UiConst.OnModelChange ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置必填项验证
        /// </summary>
        public virtual TBuilder Required() {
            AttributeIfNotEmpty( "[required]", _config.GetValue( UiConst.Required ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置必填项消息
        /// </summary>
        public virtual TBuilder RequiredMessage() {
            AttributeIfNotEmpty( "requiredMessage", _config.GetValue( UiConst.RequiredMessage ) );
            AttributeIfNotEmpty( "[requiredMessage]", _config.GetValue( AngularConst.BindRequiredMessage ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置最小长度验证
        /// </summary>
        public virtual TBuilder MinLength() {
            AttributeIfNotEmpty( "[minlength]", _config.GetValue( UiConst.MinLength ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置最小长度验证消息
        /// </summary>
        public virtual TBuilder MinLengthMessage() {
            AttributeIfNotEmpty( "minLengthMessage", _config.GetValue( UiConst.MinLengthMessage ) );
            AttributeIfNotEmpty( "[minLengthMessage]", _config.GetValue( AngularConst.BindMinLengthMessage ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置最大长度验证
        /// </summary>
        public virtual TBuilder MaxLength() {
            AttributeIfNotEmpty( "[maxlength]", _config.GetValue( UiConst.MaxLength ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置电子邮件验证消息
        /// </summary>
        public virtual TBuilder EmailMessage() {
            AttributeIfNotEmpty( "emailMessage", _config.GetValue( UiConst.EmailMessage ) );
            AttributeIfNotEmpty( "[emailMessage]", _config.GetValue( AngularConst.BindEmailMessage ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置正则表达式验证
        /// </summary>
        public virtual TBuilder Pattern() {
            AttributeIfNotEmpty( "pattern", _config.GetValue( UiConst.Pattern ) );
            AttributeIfNotEmpty( "[pattern]", _config.GetValue( AngularConst.BindPattern ) );
            AttributeIfNotEmpty( "patternMessage", _config.GetValue( UiConst.PatternMessage ) );
            AttributeIfNotEmpty( "[patternMessage]", _config.GetValue( AngularConst.BindPatternMessage ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置表单属性
        /// </summary>
        protected TBuilder ConfigForm() {
            return NgModel().FormControl().SpaceItem().OnModelChange()
                .Required().RequiredMessage()
                .MinLength().MinLengthMessage()
                .MaxLength().EmailMessage()
                .Pattern()
                .TableEdit().ValidationExtend();
        }

        /// <summary>
        /// 配置表格编辑
        /// </summary>
        protected TBuilder TableEdit() {
            var config = GetTableColumnShareConfig();
            if ( config == null || config.IsEnableEdit == false )
                return (TBuilder)this;
            var id = _config.GetValue( UiConst.Id );
            if ( id.IsEmpty() ) {
                id = $"c_{Id.Create()}";
                this.Id( id );
            }
            Attribute( "[x-edit-control]", id );
            Attribute( "[editRow]", config.RowId );
            return (TBuilder)this;
        }

        /// <summary>
        /// 获取表格列共享配置
        /// </summary>
        public TableColumnShareConfig GetTableColumnShareConfig() {
            return _config.GetValueFromItems<TableColumnShareConfig>();
        }

        /// <summary>
        /// 配置验证扩展
        /// </summary>
        protected TBuilder ValidationExtend() {
            if ( FormItemShareConfig.IsValidationExtend ) {
                Attribute( "x-validation-extend" );
                Attribute( $"#{FormItemShareConfig.ValidationExtendId}", "xValidationExtend" );
                AttributeIfNotEmpty( "displayName", FormItemShareConfig.LabelText );
            }
            return (TBuilder)this;
        }
    }
}