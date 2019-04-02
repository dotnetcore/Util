using Util.Properties;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Enums;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Tables.Configs;
using TableHeadColumnBuilder = Util.Ui.Zorro.Tables.Builders.TableHeadColumnBuilder;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 标题列渲染器
    /// </summary>
    public class HeadColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化标题列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public HeadColumnRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableHeadColumnBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TableHeadColumnBuilder builder ) {
            ConfigId( builder );
            ConfigTitle( builder );
            ConfigSort( builder );
            ConfigType( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigTitle( TableHeadColumnBuilder builder ) {
            builder.Title( GetTitle() );
        }

        /// <summary>
        /// 获取标题
        /// </summary>
        private string GetTitle() {
            return _config.GetValue( UiConst.Title );
        }

        /// <summary>
        /// 配置排序
        /// </summary>
        private void ConfigSort( TableHeadColumnBuilder builder ) {
            var shareConfig = GetShareConfig();
            var columnInfo = shareConfig?.Columns.Find( t => t.IsSort && t.Title == GetTitle() );
            if ( columnInfo != null ) {
                builder.AddSort( columnInfo.Column );
                return;
            }
            if ( _config.Contains( UiConst.Sort ) == false )
                return;
            builder.AddSort( _config.GetValue( UiConst.Sort ) );
        }

        /// <summary>
        /// 获取共享配置
        /// </summary>
        private TableShareConfig GetShareConfig() {
            return _config.Context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        private void ConfigType( TableHeadColumnBuilder builder ) {
            ConfigLineNumber( builder );
            ConfigCheckbox( builder );
        }

        /// <summary>
        /// 配置序号
        /// </summary>
        private void ConfigLineNumber( TableHeadColumnBuilder builder ) {
            if( _config.GetValue<TableColumnType?>( UiConst.Type ) != TableColumnType.LineNumber )
                return;
            builder.Title( R.LineNumber );
        }

        /// <summary>
        /// 配置复选框
        /// </summary>
        private void ConfigCheckbox( TableHeadColumnBuilder builder ) {
            if( _config.GetValue<TableColumnType?>( UiConst.Type ) != TableColumnType.Checkbox )
                return;
            var tableId = _config.Context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey )?.TableId;
            builder.AddCheckBox( tableId );
        }
    }
}