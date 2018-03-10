using Util.Ui.Builders;
using Util.Ui.Material.Tables.Builders;
using Util.Ui.Material.Tables.Configs;
using Util.Ui.Material.Tables.Renders;

namespace Util.Ui.Material.Tables.Temp {
    /// <summary>
    /// 临时表格渲染器，临时解决表头冻结问题
    /// </summary>
    public class TempTableRender : TableRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly TableConfig _config;

        /// <summary>
        /// 初始化表格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TempTableRender( TableConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected override void Config( TagBuilder builder ) {
            ConfigTableWrapper( builder );
            ConfigHeaderTable( builder );
            ConfigTable( builder );
        }

        /// <summary>
        /// 配置标题表格
        /// </summary>
        private void ConfigHeaderTable( TagBuilder builder ) {
            var tableBuilder = new TableBuilder();
            ConfigTableDefault( tableBuilder );
            ConfigSort( tableBuilder );
            ConfigContent( tableBuilder );
            ConfigHeaderTableRow( tableBuilder );
            builder.AppendContent( tableBuilder );
        }

        /// <summary>
        /// 配置表格默认属性
        /// </summary>
        private void ConfigTableDefault( TagBuilder tableBuilder ) {
            tableBuilder.AddAttribute( "matSort" );
            tableBuilder.Class( "tableHeader" );
        }

        /// <summary>
        /// 配置标题表格行
        /// </summary>
        private void ConfigHeaderTableRow( TagBuilder tableBuilder ) {
            if( _config.Columns == null || _config.Columns.Count == 0 )
                return;
            var columns = Util.Helpers.Json.ToJson( _config.Columns, true );
            var headerRowBuilder = new TableHeaderRowBuilder();
            headerRowBuilder.AddColumns( columns );
            tableBuilder.AppendContent( headerRowBuilder );
        }

        /// <summary>
        /// 添加行头
        /// </summary>
        protected override void AddHeaderRow( TagBuilder tableBuilder, string columns ) {
            var headerRowBuilder = new TableHeaderRowBuilder();
            headerRowBuilder.AddColumns( columns );
            headerRowBuilder.AddAttribute( "style", "display: none" );
            tableBuilder.AppendContent( headerRowBuilder );
        }
    }
}