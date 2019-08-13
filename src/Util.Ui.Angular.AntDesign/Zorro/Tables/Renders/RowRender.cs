using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables.Builders;
using Util.Ui.Zorro.Tables.Configs;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 行渲染器
    /// </summary>
    public class RowRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格标识
        /// </summary>
        private readonly string _tableId;

        /// <summary>
        /// 初始化行渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tableId">表格标识</param>
        public RowRender( Config config, string tableId ) : base( config ) {
            _config = config;
            _tableId = tableId;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableBodyBuilder();
            var rowBuilder = new RowBuilder();
            builder.AppendContent( rowBuilder );
            Config( rowBuilder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( RowBuilder builder ) {
            var config = _config.GetValueFromItems<TableShareConfig>();
            InitBuilder( builder );
            ConfigId( builder );
            ConfigVariable( builder );
            ConfigEdit( builder, config );
            ConfigEvents( builder, config );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置循环变量
        /// </summary>
        private void ConfigVariable( RowBuilder builder ) {
            if( _tableId.IsEmpty() )
                return;
            builder.ConfigIterationVar( _tableId );
        }

        /// <summary>
        /// 添加行编辑属性
        /// </summary>
        private void ConfigEdit( RowBuilder builder, TableShareConfig config ) {
            if ( config == null )
                return;
            if( config.IsEdit == false )
                return;
            builder.ConfigEdit( config.EditTableId, config.RowId );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( RowBuilder builder, TableShareConfig config ) {
            ConfigOnClick( builder, config );
        }

        /// <summary>
        /// 配置行单击事件
        /// </summary>
        private void ConfigOnClick( RowBuilder builder, TableShareConfig config ) {
            if( _config.Contains( UiConst.OnClick ) ) {
                builder.AddAttribute( "(click)", _config.GetValue( UiConst.OnClick ) );
                return;
            }
            builder.AddAttribute( "(click)", config?.OnClickRow );
        }
    }
}