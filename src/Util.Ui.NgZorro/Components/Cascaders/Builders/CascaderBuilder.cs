using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Cascaders.Builders {
    /// <summary>
    /// 级联选择标签生成器
    /// </summary>
    public class CascaderBuilder : FormControlBuilderBase<CascaderBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化级联选择标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public CascaderBuilder( Config config ) : base( config, "nz-cascader" ) {
            _config = config;
        }

        /// <summary>
        /// 配置允许清除
        /// </summary>
        public CascaderBuilder AllowClear() {
            AttributeIfNotEmpty( "[nzAllowClear]", _config.GetBoolValue( UiConst.AllowClear ) );
            AttributeIfNotEmpty( "[nzAllowClear]", _config.GetValue( AngularConst.BindAllowClear ) );
            return this;
        }

        /// <summary>
        /// 配置自动聚焦
        /// </summary>
        public CascaderBuilder AutoFocus() {
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetBoolValue( UiConst.AutoFocus ) );
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetValue( AngularConst.BindAutoFocus ) );
            return this;
        }

        /// <summary>
        /// 配置变更函数
        /// </summary>
        public CascaderBuilder ChangeOn() {
            AttributeIfNotEmpty( "[nzChangeOn]", _config.GetValue( UiConst.ChangeOn ) );
            return this;
        }

        /// <summary>
        /// 配置选择变更
        /// </summary>
        public CascaderBuilder ChangeOnSelect() {
            AttributeIfNotEmpty( "[nzChangeOnSelect]", _config.GetBoolValue( UiConst.ChangeOnSelect ) );
            AttributeIfNotEmpty( "[nzChangeOnSelect]", _config.GetValue( AngularConst.BindChangeOnSelect ) );
            return this;
        }

        /// <summary>
        /// 配置列类名
        /// </summary>
        public CascaderBuilder ColumnClassName() {
            AttributeIfNotEmpty( "nzColumnClassName", _config.GetBoolValue( UiConst.ColumnClassName ) );
            AttributeIfNotEmpty( "[nzColumnClassName]", _config.GetValue( AngularConst.BindColumnClassName ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public CascaderBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置展开图标
        /// </summary>
        public CascaderBuilder ExpandIcon() {
            AttributeIfNotEmpty( "nzExpandIcon", _config.GetValue<AntDesignIcon?>( UiConst.ExpandIcon )?.Description() );
            AttributeIfNotEmpty( "[nzExpandIcon]", _config.GetValue( AngularConst.BindExpandIcon ) );
            return this;
        }

        /// <summary>
        /// 配置展开方式
        /// </summary>
        public CascaderBuilder ExpandTrigger() {
            AttributeIfNotEmpty( "nzExpandTrigger", _config.GetValue<CascaderExpandTrigger?>( UiConst.ExpandTrigger )?.Description() );
            AttributeIfNotEmpty( "[nzExpandTrigger]", _config.GetValue( AngularConst.BindExpandTrigger ) );
            return this;
        }

        /// <summary>
        /// 配置标签属性名
        /// </summary>
        public CascaderBuilder LabelProperty() {
            AttributeIfNotEmpty( "nzLabelProperty", _config.GetValue( UiConst.LabelProperty ) );
            AttributeIfNotEmpty( "[nzLabelProperty]", _config.GetValue( AngularConst.BindLabelProperty ) );
            return this;
        }

        /// <summary>
        /// 配置标签渲染模板
        /// </summary>
        public CascaderBuilder LabelRender() {
            AttributeIfNotEmpty( "[nzLabelRender]", _config.GetValue( UiConst.LabelRender ) );
            return this;
        }

        /// <summary>
        /// 配置动态加载函数
        /// </summary>
        public CascaderBuilder LoadData() {
            AttributeIfNotEmpty( "[nzLoadData]", _config.GetValue( UiConst.LoadData ) );
            return this;
        }

        /// <summary>
        /// 配置浮层类名
        /// </summary>
        public CascaderBuilder MenuClassName() {
            AttributeIfNotEmpty( "nzMenuClassName", _config.GetValue( UiConst.MenuClassName ) );
            AttributeIfNotEmpty( "[nzMenuClassName]", _config.GetValue( AngularConst.BindMenuClassName ) );
            return this;
        }

        /// <summary>
        /// 配置浮层样式
        /// </summary>
        public CascaderBuilder MenuStyle() {
            AttributeIfNotEmpty( "nzMenuStyle", _config.GetValue( UiConst.MenuStyle ) );
            AttributeIfNotEmpty( "[nzMenuStyle]", _config.GetValue( AngularConst.BindMenuStyle ) );
            return this;
        }

        /// <summary>
        /// 配置空列表默认内容
        /// </summary>
        public CascaderBuilder NotFoundContent() {
            AttributeIfNotEmpty( "nzNotFoundContent", _config.GetValue( UiConst.NotFoundContent ) );
            AttributeIfNotEmpty( "[nzNotFoundContent]", _config.GetValue( AngularConst.BindNotFoundContent ) );
            return this;
        }

        /// <summary>
        /// 配置选项渲染模板
        /// </summary>
        public CascaderBuilder OptionRender() {
            AttributeIfNotEmpty( "[nzOptionRender]", _config.GetValue( UiConst.OptionRender ) );
            return this;
        }

        /// <summary>
        /// 配置可选项数据源
        /// </summary>
        public CascaderBuilder Options() {
            AttributeIfNotEmpty( "[nzOptions]", _config.GetValue( UiConst.Options ) );
            return this;
        }

        /// <summary>
        /// 配置占位提示
        /// </summary>
        public CascaderBuilder Placeholder() {
            AttributeIfNotEmpty( "nzPlaceHolder", _config.GetValue( UiConst.Placeholder ) );
            AttributeIfNotEmpty( "[nzPlaceHolder]", _config.GetValue( AngularConst.BindPlaceholder ) );
            return this;
        }

        /// <summary>
        /// 配置显示箭头
        /// </summary>
        public CascaderBuilder ShowArrow() {
            AttributeIfNotEmpty( "[nzShowArrow]", _config.GetBoolValue( UiConst.ShowArrow ) );
            AttributeIfNotEmpty( "[nzShowArrow]", _config.GetValue( AngularConst.BindShowArrow ) );
            return this;
        }

        /// <summary>
        /// 配置显示输入框
        /// </summary>
        public CascaderBuilder ShowInput() {
            AttributeIfNotEmpty( "[nzShowInput]", _config.GetBoolValue( UiConst.ShowInput ) );
            AttributeIfNotEmpty( "[nzShowInput]", _config.GetValue( AngularConst.BindShowInput ) );
            return this;
        }

        /// <summary>
        /// 配置显示搜索
        /// </summary>
        public CascaderBuilder ShowSearch() {
            AttributeIfNotEmpty( "[nzShowSearch]", _config.GetBoolValue( UiConst.ShowSearch ) );
            AttributeIfNotEmpty( "[nzShowSearch]", _config.GetValue( AngularConst.BindShowSearch ) );
            return this;
        }

        /// <summary>
        /// 配置输入框大小
        /// </summary>
        public CascaderBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置选择框后缀图标
        /// </summary>
        public CascaderBuilder SuffixIcon() {
            AttributeIfNotEmpty( "nzSuffixIcon", _config.GetValue<AntDesignIcon?>( UiConst.SuffixIcon )?.Description() );
            AttributeIfNotEmpty( "[nzSuffixIcon]", _config.GetValue( AngularConst.BindSuffixIcon ) );
            return this;
        }

        /// <summary>
        /// 配置值属性名
        /// </summary>
        public CascaderBuilder ValueProperty() {
            AttributeIfNotEmpty( "nzValueProperty", _config.GetBoolValue( UiConst.ValueProperty ) );
            AttributeIfNotEmpty( "[nzValueProperty]", _config.GetValue( AngularConst.BindValueProperty ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public CascaderBuilder Events() {
            AttributeIfNotEmpty( "(nzClear)", _config.GetValue( UiConst.OnClear ) );
            AttributeIfNotEmpty( "(nzVisibleChange)", _config.GetValue( UiConst.OnVisibleChange ) );
            AttributeIfNotEmpty( "(nzSelectionChange)", _config.GetValue( UiConst.OnSelectionChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().AllowClear().AutoFocus().ChangeOn().ChangeOnSelect().ColumnClassName()
                .Disabled().ExpandIcon().ExpandTrigger().LabelProperty().LabelRender().LoadData()
                .MenuClassName().MenuStyle().NotFoundContent().OptionRender().Options()
                .Placeholder().ShowArrow().ShowInput().ShowSearch().Size().SuffixIcon()
                .ValueProperty().Events();
        }
    }
}