using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表头标签生成器
    /// </summary>
    public class TableHeadBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private TableShareConfig _tableShareConfig;

        /// <summary>
        /// 初始化表头标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TableHeadBuilder( Config config ) : base( config,"thead" ) {
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
        /// 创建表头行标签生成器
        /// </summary>
        public virtual TableHeadRowBuilder CreateTableHeadRowBuilder() {
            return new TableHeadRowBuilder( _config.CopyRemoveId() );
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigAutoCreate();
            ConfigContent();
        }

        /// <summary>
        /// 配置自动创建嵌套结构
        /// </summary>
        public void ConfigAutoCreate() {
            var service = new TableHeadAutoCreateService( this );
            service.Init();
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        public void ConfigContent() {
            if ( _tableShareConfig.HeadRowAutoCreated )
                return;
            _config.Content.AppendTo( this );
        }
    }
}