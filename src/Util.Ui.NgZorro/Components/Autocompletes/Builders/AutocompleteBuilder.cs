using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Containers.Builders;
using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.Autocompletes.Builders {
    /// <summary>
    /// 自动完成标签生成器
    /// </summary>
    public class AutocompleteBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 标识
        /// </summary>
        private string _id;

        /// <summary>
        /// 初始化自动完成标签生成器
        /// </summary>
        public AutocompleteBuilder( Config config ) : base( config, "nz-autocomplete" ) {
            _config = config;
        }

        /// <summary>
        /// 扩展标识
        /// </summary>
        protected string ExtendId => $"x_{GetId()}";

        /// <summary>
        /// 获取标识
        /// </summary>
        private string GetId() {
            if ( _id.IsEmpty() == false )
                return _id;
            _id = _config.GetValue( UiConst.Id );
            if ( _id.IsEmpty() )
                _id = Util.Helpers.Id.Create();
            return _id;
        }

        /// <summary>
        /// 配置回填选中项
        /// </summary>
        public AutocompleteBuilder Backfill() {
            AttributeIfNotEmpty( "[nzBackfill]", _config.GetBoolValue( UiConst.Backfill ) );
            AttributeIfNotEmpty( "[nzBackfill]", _config.GetValue( AngularConst.BindBackfill ) );
            return this;
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        public AutocompleteBuilder DataSource() {
            AttributeIfNotEmpty( "[nzDataSource]", _config.GetValue( UiConst.Datasource ) );
            return this;
        }

        /// <summary>
        /// 配置高亮第一项
        /// </summary>
        public AutocompleteBuilder DefaultActiveFirstOption() {
            AttributeIfNotEmpty( "[nzDefaultActiveFirstOption]", _config.GetBoolValue( UiConst.DefaultActiveFirstOption ) );
            AttributeIfNotEmpty( "[nzDefaultActiveFirstOption]", _config.GetValue( AngularConst.BindDefaultActiveFirstOption ) );
            return this;
        }

        /// <summary>
        /// 配置宽度
        /// </summary>
        public AutocompleteBuilder Width() {
            AttributeIfNotEmpty( "[nzWidth]", _config.GetBoolValue( UiConst.Width ) );
            AttributeIfNotEmpty( "[nzWidth]", _config.GetValue( AngularConst.BindWidth ) );
            return this;
        }

        /// <summary>
        /// 配置下拉根元素类名
        /// </summary>
        public AutocompleteBuilder OverlayClassName() {
            AttributeIfNotEmpty( "nzOverlayClassName", _config.GetValue( UiConst.OverlayClassName ) );
            AttributeIfNotEmpty( "[nzOverlayClassName]", _config.GetValue( AngularConst.BindOverlayClassName ) );
            return this;
        }

        /// <summary>
        /// 配置下拉根元素样式
        /// </summary>
        public AutocompleteBuilder OverlayStyle() {
            AttributeIfNotEmpty( "nzOverlayStyle", _config.GetValue( UiConst.OverlayStyle ) );
            AttributeIfNotEmpty( "[nzOverlayStyle]", _config.GetValue( AngularConst.BindOverlayStyle ) );
            return this;
        }

        /// <summary>
        /// 配置比较算法函数
        /// </summary>
        public AutocompleteBuilder CompareWith() {
            AttributeIfNotEmpty( "[compareWith]", _config.GetValue( UiConst.CompareWith ) );
            return this;
        }

        /// <summary>
        /// 配置自动加载
        /// </summary>
        private AutocompleteBuilder AutoLoad() {
            AttributeIfNotEmpty( "[autoLoad]", _config.GetBoolValue( UiConst.AutoLoad ) );
            return this;
        }

        /// <summary>
        /// 配置查询参数
        /// </summary>
        private AutocompleteBuilder QueryParam() {
            AttributeIfNotEmpty( "[(queryParam)]", _config.GetValue( UiConst.QueryParam ) );
            return this;
        }

        /// <summary>
        /// 配置排序条件
        /// </summary>
        private AutocompleteBuilder Sort() {
            AttributeIfNotEmpty( "order", _config.GetValue( UiConst.Sort ) );
            AttributeIfNotEmpty( "[order]", _config.GetValue( AngularConst.BindSort ) );
            return this;
        }

        /// <summary>
        /// 配置Api地址
        /// </summary>
        private AutocompleteBuilder Url() {
            AttributeIfNotEmpty( "url", _config.GetValue( UiConst.Url ) );
            AttributeIfNotEmpty( "[url]", _config.GetValue( AngularConst.BindUrl ) );
            return this;
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private AutocompleteBuilder Data() {
            AttributeIfNotEmpty( "[data]", _config.GetValue( UiConst.Data ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            Backfill().DataSource().DefaultActiveFirstOption().Width()
                .OverlayClassName().OverlayStyle().CompareWith()
                .AutoLoad().QueryParam().Sort().Url().Data();
            EnableExtend();
        }

        /// <summary>
        /// 启用扩展
        /// </summary>
        public AutocompleteBuilder EnableExtend() {
            if ( IsEnableExtend() == false )
                return this;
            Attribute( $"#{ExtendId}", "xSelectExtend" );
            Attribute( "x-select-extend" );
            ConfigOption();
            ConfigOptionGroup();
            return this;
        }

        /// <summary>
        /// 是否启用基础扩展
        /// </summary>
        public bool IsEnableExtend() {
            if ( GetEnableExtend() == false ) {
                return false;
            }
            if ( GetEnableExtend() == true ||
                 GetUrl().IsEmpty() == false ||
                 GetBindUrl().IsEmpty() == false ||
                 GetData().IsEmpty() == false ) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取启用扩展属性
        /// </summary>
        private bool? GetEnableExtend() {
            return _config.GetValue<bool?>( UiConst.EnableExtend );
        }

        /// <summary>
        /// 获取地址
        /// </summary>
        private string GetUrl() {
            return _config.GetValue( UiConst.Url );
        }

        /// <summary>
        /// 获取地址
        /// </summary>
        private string GetBindUrl() {
            return _config.GetValue( AngularConst.BindUrl );
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        private string GetData() {
            return _config.GetValue( UiConst.Data );
        }

        /// <summary>
        /// 配置选项
        /// </summary>
        private void ConfigOption() {
            var containerBuilder = new ContainerBuilder( _config );
            containerBuilder.NgIf( $"!{ExtendId}.isGroup" );
            var optionBuilder = new AutoOptionBuilder( _config );
            containerBuilder.AppendContent( optionBuilder );
            optionBuilder.NgFor( $"let item of {ExtendId}.options" );
            ConfigOptionLabel( optionBuilder );
            optionBuilder.BindValue( "item.value" );
            optionBuilder.Disabled( "item.disabled" );
            AppendContent( containerBuilder );
        }

        /// <summary>
        /// 配置标签文本
        /// </summary>
        private void ConfigOptionLabel( AutoOptionBuilder optionBuilder ) {
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                optionBuilder.BindLabel( "item.text|i18n" );
                optionBuilder.SetContent( "{{" + "item.text|i18n" + "}}");
                return;
            }
            optionBuilder.BindLabel( "item.text" );
            optionBuilder.SetContent( "{{item.text}}" );
        }

        /// <summary>
        /// 配置选项组
        /// </summary>
        private void ConfigOptionGroup() {
            var containerBuilder = new ContainerBuilder( _config );
            containerBuilder.NgIf( $"{ExtendId}.isGroup" );
            var groupBuilder = new AutoOptionGroupBuilder( _config );
            containerBuilder.AppendContent( groupBuilder );
            groupBuilder.NgFor( $"let group of {ExtendId}.optionGroups" );
            groupBuilder.BindLabel( "group.text" );
            var optionBuilder = new AutoOptionBuilder( _config );
            groupBuilder.AppendContent( optionBuilder );
            optionBuilder.NgFor( "let item of group.value" );
            ConfigOptionLabel( optionBuilder );
            optionBuilder.BindValue( "item.value" );
            optionBuilder.Disabled( "item.disabled" );
            AppendContent( containerBuilder );
        }
    }
}