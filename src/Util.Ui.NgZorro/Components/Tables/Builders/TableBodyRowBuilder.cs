using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.Extensions;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格主体行标签生成器
    /// </summary>
    public class TableBodyRowBuilder : TableRowBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格主体行标签生成器
        /// </summary>
        public TableBodyRowBuilder( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ConfigTableExted();
            ConfigContent();
        }

        /// <summary>
        /// 配置表格主体行基础扩展属性
        /// </summary>
        public void ConfigTableExted() {
            if ( GetTableShareConfig().IsAutoCreateBodyRow == false )
                return;
            if ( GetTableShareConfig().IsEnableExtend == false )
                return;
            this.NgFor( $"let row of {GetTableShareConfig().TableExtendId}.dataSource;index as index" );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        public void ConfigContent() {
            _config.Content.AppendTo( this );
        }
    }
}