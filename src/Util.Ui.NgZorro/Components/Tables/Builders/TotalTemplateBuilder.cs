using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Templates.Builders;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格总行数模板标签生成器
    /// </summary>
    public class TotalTemplateBuilder : TemplateBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private TableShareConfig _tableShareConfig;

        /// <summary>
        /// 初始化表格行标签生成器
        /// </summary>
        public TotalTemplateBuilder( Config config ) : base( config ) {
            _config = config;
            _tableShareConfig = GetTableShareConfig();
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        public TableShareConfig GetTableShareConfig() {
            return _tableShareConfig ??= _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            Attribute( $"#{_tableShareConfig.TotalTemplateId}" );
            Attribute( "let-range", "range" );
            Attribute( "let-total" );
            SetContent( "{{ 'util.tableTotalTemplate'|i18n:{start:range[0],end:range[1],total:total} }}" );
        }
    }
}