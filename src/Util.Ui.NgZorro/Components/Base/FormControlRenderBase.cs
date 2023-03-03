using Microsoft.AspNetCore.Html;
using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Builders;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Components.Templates.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Extensions;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 表单控件渲染器基类
    /// </summary>
    public abstract class FormControlRenderBase : IRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表单项共享配置
        /// </summary>
        private readonly FormItemShareConfig _shareConfig;
        /// <summary>
        /// 标识
        /// </summary>
        private string _id;

        /// <summary>
        /// 初始化表单控件渲染器基类
        /// </summary>
        /// <param name="config">配置</param>
        protected FormControlRenderBase( Config config ) {
            _config = config;
            _shareConfig = GetFormItemShareConfig();
        }

        /// <summary>
        /// 获取表单项共享配置
        /// </summary>
        private FormItemShareConfig GetFormItemShareConfig() {
            return _config.GetValueFromItems<FormItemShareConfig>() ?? new FormItemShareConfig();
        }

        /// <summary>
        /// 获取标识
        /// </summary>
        protected virtual string GetId() {
            if ( _id.IsEmpty() == false )
                return _id;
            _id = _config.GetValue( UiConst.Id );
            if ( _id.IsEmpty() == false )
                return _id;
            return _id = Util.Helpers.Id.Create();
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            Init();
            var formItem = GetFormItem();
            var formLabel = GetFormLabel();
            var formControl = GetFormControl();
            formItem.AppendContent( formLabel ).AppendContent( formControl );
            formItem.WriteTo( writer,encoder );
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init() {
        }

        /// <summary>
        /// 设置控件Id
        /// </summary>
        protected void SetControlId() {
            if( _shareConfig.AutoLabelFor != true )
                return;
            _config.SetAttribute( AngularConst.RawId, _shareConfig.ControlId );
        }

        /// <summary>
        /// 获取表单项
        /// </summary>
        private TagBuilder GetFormItem() {
            TagBuilder builder = new EmptyContainerTagBuilder();
            if ( _config.Id == _shareConfig.Id && _shareConfig.AutoCreateFormItem == true )
                builder = new FormItemBuilder( _config.CopyRemoveId() );
            builder.Config();
            return builder;
        }

        /// <summary>
        /// 获取表单标签
        /// </summary>
        private TagBuilder GetFormLabel() {
            if ( _config.Id == _shareConfig.Id && _shareConfig.AutoCreateFormLabel == true ) {
                var builder = new FormLabelBuilder( _config.CopyRemoveId() );
                builder.Config();
                SetLabelText( builder );
                return builder;
            }
            return new EmptyContainerTagBuilder();
        }

        /// <summary>
        /// 设置表单标签文本
        /// </summary>
        private void SetLabelText( FormLabelBuilder builder ) {
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                builder.AppendContentByI18n( _shareConfig.LabelText );
                return;
            }
            builder.SetContent( _shareConfig.LabelText );
        }

        /// <summary>
        /// 获取表单控件
        /// </summary>
        private TagBuilder GetFormControl() {
            TagBuilder builder = new EmptyContainerTagBuilder();
            if( _config.Id == _shareConfig.Id && _shareConfig.AutoCreateFormControl == true )
                builder = new FormControlBuilder( _config.CopyRemoveId() );
            builder.Config();
            AppendControl( builder );
            AppendValidationTempalte( builder );
            return builder;
        }

        /// <summary>
        /// 添加表单控件
        /// </summary>
        protected virtual void AppendControl( TagBuilder formControlBuilder ) {
        }

        /// <summary>
        /// 添加验证模板
        /// </summary>
        private void AppendValidationTempalte( TagBuilder formControlBuilder ) {
            if ( _shareConfig.ValidationTempalteId.IsEmpty() )
                return;
            var templateBuilder = new TemplateBuilder( _config.CopyRemoveId() );
            templateBuilder.Id( _shareConfig.ValidationTempalteId );
            templateBuilder.SetContent( $"{{{{{_shareConfig.ValidationExtendId}.getErrorMessage()}}}}" );
            formControlBuilder.AppendContent( templateBuilder );
        }

        /// <inheritdoc />
        public abstract IHtmlContent Clone();
    }
}