using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgZorro.Components.Autocompletes.Builders {
    /// <summary>
    /// 自动完成标签生成器
    /// </summary>
    public class AutocompleteBuilder : FormControlBuilderBase<AutocompleteBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化自动完成标签生成器
        /// </summary>
        public AutocompleteBuilder( Config config ) : base( config, "nz-autocomplete" ) {
            _config = config;
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
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Backfill().DataSource().DefaultActiveFirstOption().Width()
                .OverlayClassName().OverlayStyle().CompareWith();
        }
    }
}