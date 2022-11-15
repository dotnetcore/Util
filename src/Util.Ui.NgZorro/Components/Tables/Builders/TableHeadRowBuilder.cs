using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表头行标签生成器
    /// </summary>
    public class TableHeadRowBuilder : TableRowBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格主体行标签生成器
        /// </summary>
        public TableHeadRowBuilder( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 创建表头单元格标签生成器
        /// </summary>
        public virtual TableHeadColumnBuilder CreateTableHeadColumnBuilder() {
            return new TableHeadColumnBuilder( _config.CopyRemoveId(), GetTableHeadColumnShareConfig() );
        }

        /// <summary>
        /// 获取表头列共享配置
        /// </summary>
        protected TableHeadColumnShareConfig GetTableHeadColumnShareConfig() {
            return _config.GetValueFromItems<TableHeadColumnShareConfig>() ?? new TableHeadColumnShareConfig( GetTableShareConfig() );
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        private TableShareConfig GetTableShareConfig() {
            return _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ConfigAutoCreate();
            ConfigContent();
        }

        /// <summary>
        /// 配置自动创建嵌套结构
        /// </summary>
        public void ConfigAutoCreate() {
            var service = new TableHeadRowAutoCreateService( this );
            service.Init();
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        public void ConfigContent() {
            if ( TableShareConfig.HeadColumnAutoCreated )
                return;
            _config.Content.AppendTo( this );
        }
    }
}