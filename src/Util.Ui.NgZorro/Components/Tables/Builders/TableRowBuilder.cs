using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格行标签生成器
    /// </summary>
    public class TableRowBuilder : TagBuilder {
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
        public TableRowBuilder( Config config ) : base( "tr" ) {
            _config = config;
            _tableShareConfig = GetTableShareConfig();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        public Config GetConfig() {
            return _config;
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        public TableShareConfig GetTableShareConfig() {
            return _tableShareConfig ??= _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 配置当前列是否展开
        /// </summary>
        public TableRowBuilder Expand() {
            AttributeIfNotEmpty( "[nzExpand]", _config.GetValue( UiConst.Expand ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Expand();
        }
    }
}