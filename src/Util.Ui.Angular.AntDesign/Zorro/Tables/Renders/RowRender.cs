using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 行渲染器
    /// </summary>
    public class RowRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;
        /// <summary>
        /// 表格标识
        /// </summary>
        private readonly string _tableId;

        /// <summary>
        /// 初始化行渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tableId">表格标识</param>
        public RowRender( IConfig config, string tableId ) : base( config ) {
            _config = config;
            _tableId = tableId;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableBodyBuilder();
            var rowBuilder = new TableRowBuilder();
            builder.AppendContent( rowBuilder );
            Config( rowBuilder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TableRowBuilder builder ) {
            InitBuilder( builder );
            ConfigId( builder );
            ConfigVariable( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置循环变量
        /// </summary>
        private void ConfigVariable( TableRowBuilder builder ) {
            if ( _tableId.IsEmpty() )
                return;
            builder.NgFor( $"let row of {_tableId}.data" );
        }
    }
}