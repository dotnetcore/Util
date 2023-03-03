using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Icons.Builders;
using Util.Ui.NgZorro.Components.Inputs.Builders;
using Util.Ui.NgZorro.Components.Inputs.Configs;
using Util.Ui.NgZorro.Components.Mentions.Configs;
using Util.Ui.NgZorro.Components.Templates.Builders;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Inputs.Renders {
    /// <summary>
    /// 输入框渲染器基类
    /// </summary>
    public abstract class InputRenderBase : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化输入框渲染器基类
        /// </summary>
        /// <param name="config">配置</param>
        protected InputRenderBase( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取清除图标模板标识
        /// </summary>
        protected string GetClearTemplateId() {
            return $"clear_{GetId()}";
        }

        /// <summary>
        /// 获取ngModel引用变量名称
        /// </summary>
        protected string GetNgModelId() {
            return $"model_{GetId()}";
        }

        /// <summary>
        /// 添加表单控件
        /// </summary>
        protected override void AppendControl( TagBuilder formControlBuilder ) {
            var inputGroup = GetInputGroup();
            var input = GetInput();
            inputGroup.AppendContent( input );
            var clearTemplate = GetClearTemplate();
            formControlBuilder.AppendContent( inputGroup ).AppendContent( clearTemplate );
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init() {
            SetControlId();
            InitAllowClear();
        }

        /// <summary>
        /// 初始化清除内容
        /// </summary>
        protected void InitAllowClear() {
            if( _config.GetValue<bool?>( UiConst.AllowClear ) == true )
                _config.SetAttribute( AngularConst.BindSuffix, GetClearTemplateId() );
        }

        /// <summary>
        /// 获取输入框组合
        /// </summary>
        private TagBuilder GetInputGroup() {
            if( NeedCreateInputGroup() )
                return GetInputGroupBuilder();
            return new EmptyContainerTagBuilder();
        }

        /// <summary>
        /// 是否需要创建输入框组合
        /// </summary>
        protected virtual bool NeedCreateInputGroup() {
            var shareConfig = GetInputGroupShareConfig();
            if ( shareConfig.AutoCreateInputGroup == true )
                return true;
            if( _config.GetValue<bool?>( UiConst.AllowClear ) == true )
                return true;
            return false;
        }

        /// <summary>
        /// 获取输入框组合共享配置
        /// </summary>
        private InputGroupShareConfig GetInputGroupShareConfig() {
            return _config.GetValueFromItems<InputGroupShareConfig>() ?? new InputGroupShareConfig();
        }

        /// <summary>
        /// 获取输入框组合标签生成器
        /// </summary>
        private TagBuilder GetInputGroupBuilder() {
            var builder = new InputGroupBuilder( _config.CopyRemoveId() );
            builder.Config();
            builder.Class( GetInputGroupClass() );
            return builder;
        }

        /// <summary>
        /// 获取输入框组合的样式类
        /// </summary>
        protected virtual string GetInputGroupClass() {
            return null;
        }

        /// <summary>
        /// 获取输入框
        /// </summary>
        private TagBuilder GetInput() {
            var builder = GetInputBuilder();
            ExportNgModel( builder );
            ConfigMentionTrigger( builder );
            return builder;
        }

        /// <summary>
        /// 获取输入框标签生成器
        /// </summary>
        protected abstract TagBuilder GetInputBuilder();

        /// <summary>
        /// 导出ngModel
        /// </summary>
        public void ExportNgModel( TagBuilder builder ) {
            if( NeedExportNgModel() )
                builder.Attribute( $"#{GetNgModelId()}", "ngModel" );
        }

        /// <summary>
        /// 是否需要导出ngModel
        /// </summary>
        private bool NeedExportNgModel() {
            if( _config.Contains( UiConst.AllowClear ) )
                return true;
            return false;
        }

        /// <summary>
        /// 配置提及触发元素
        /// </summary>
        private void ConfigMentionTrigger( TagBuilder builder ) {
            var shareConfig = _config.GetValueFromItems<MentionShareConfig>();
            if( shareConfig == null )
                return;
            builder.Attribute( "nzMentionTrigger" );
        }

        /// <summary>
        /// 获取清除模板
        /// </summary>
        private TagBuilder GetClearTemplate() {
            if( _config.Contains( UiConst.AllowClear ) == false )
                return new EmptyTagBuilder();
            var templateBuilder = new TemplateBuilder( _config );
            templateBuilder.Id( GetClearTemplateId() );
            var iconBuilder = GetClearIconBuilder();
            templateBuilder.SetContent( iconBuilder );
            return templateBuilder;
        }

        /// <summary>
        /// 获取清除图标标签生成器
        /// </summary>
        private TagBuilder GetClearIconBuilder() {
            var builder = new IconBuilder( _config );
            builder.Class( GetClearIconClass() );
            builder.Theme( IconTheme.Fill ).Type( AntDesignIcon.CloseCircle );
            builder.NgIf( $"{GetNgModelId()}.value" );
            builder.OnClick( $"{GetNgModelId()}.reset()" );
            return builder;
        }

        /// <summary>
        /// 获取清除图标的样式类
        /// </summary>
        protected virtual string GetClearIconClass() {
            return "ant-input-clear-icon";
        }
    }
}