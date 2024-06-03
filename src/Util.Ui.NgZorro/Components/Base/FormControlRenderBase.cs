using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Forms.Builders;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Components.Templates.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Extensions;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Base;

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
    protected readonly FormItemShareConfig ShareConfig;
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
        ShareConfig = GetFormItemShareConfig();
    }

    /// <summary>
    /// 获取表单项共享配置
    /// </summary>
    protected FormItemShareConfig GetFormItemShareConfig() {
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
        formItem.WriteTo( writer, encoder );
    }

    /// <summary>
    /// 初始化
    /// </summary>
    protected virtual void Init() {
    }

    /// <summary>
    /// 获取表单项
    /// </summary>
    protected virtual TagBuilder GetFormItem() {
        TagBuilder builder = new EmptyContainerTagBuilder();
        if (_config.Id == ShareConfig.Id && ShareConfig.AutoCreateFormItem == true) {
            builder = new FormItemBuilder(_config.CopyRemoveAttributes());
            ShareConfig.FormItemCreated = true;
        }
        builder.Config();
        return builder;
    }

    /// <summary>
    /// 获取表单标签
    /// </summary>
    protected virtual TagBuilder GetFormLabel() {
        if ( _config.Id == ShareConfig.Id && ShareConfig.AutoCreateFormLabel == true ) {
            var builder = new FormLabelBuilder( GetFormLabelConfig() );
            builder.Config();
            SetLabelText( builder );
            SetBindLabelText( builder );
            return builder;
        }
        return new EmptyContainerTagBuilder();
    }

    /// <summary>
    /// 获取表单标签配置
    /// </summary>
    protected Config GetFormLabelConfig() {
        var result = _config.CopyRemoveAttributes();
        result.Content = null;
        return result;
    }

    /// <summary>
    /// 设置表单标签文本
    /// </summary>
    protected virtual void SetLabelText( FormLabelBuilder builder ) {
        if ( ShareConfig.LabelText.IsEmpty() )
            return;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            builder.AppendContentByI18n( ShareConfig.LabelText );
            return;
        }
        builder.SetContent( ShareConfig.LabelText );
    }

    /// <summary>
    /// 设置表单标签文本
    /// </summary>
    protected virtual void SetBindLabelText( FormLabelBuilder builder ) {
        if ( ShareConfig.BindLabelText.IsEmpty() )
            return;
        builder.SetContent( "{{" + ShareConfig.BindLabelText + "}}" );
    }

    /// <summary>
    /// 获取表单控件
    /// </summary>
    protected virtual TagBuilder GetFormControl() {
        TagBuilder builder = new EmptyContainerTagBuilder();
        if ( _config.Id == ShareConfig.Id && ShareConfig.AutoCreateFormControl == true )
            builder = new FormControlBuilder( _config.CopyRemoveAttributes() );
        builder.Config();
        AppendControl( builder );
        if ( IsAppendValidationTempalte() )
            AppendValidationTempalte( builder );
        return builder;
    }

    /// <summary>
    /// 添加表单控件
    /// </summary>
    protected virtual void AppendControl( TagBuilder formControlBuilder ) {
    }

    /// <summary>
    /// 是否添加验证模板
    /// </summary>
    protected virtual bool IsAppendValidationTempalte() {
        return true;
    }

    /// <summary>
    /// 添加验证模板
    /// </summary>
    protected virtual void AppendValidationTempalte( TagBuilder formControlBuilder ) {
        if ( ShareConfig.ValidationTempalteId.IsEmpty() )
            return;
        var templateBuilder = new TemplateBuilder( _config.CopyRemoveAttributes() );
        templateBuilder.Id( ShareConfig.ValidationTempalteId );
        templateBuilder.SetContent( $"{{{{{ShareConfig.ValidationExtendId}.getErrorMessage()}}}}" );
        formControlBuilder.AppendContent( templateBuilder );
    }

    /// <inheritdoc />
    public abstract IHtmlContent Clone();
}