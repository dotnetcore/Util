using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格文本单元格标签生成器
    /// </summary>
    public class TableColumnTextBuilder : TableColumnBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格文本单元格标签生成器
        /// </summary>
        public TableColumnTextBuilder( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 配置列名
        /// </summary>
        public TableColumnTextBuilder Column() {
            var column = _config.GetValue( UiConst.Column );
            if ( column.IsEmpty() == false )
                AppendContent( $"{{{{row.{column}}}}}" );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Column();
        }
    }
}