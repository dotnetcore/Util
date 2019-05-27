using Util.Ui.Angular.Enums;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Tables.Configs {
    /// <summary>
    /// 列配置
    /// </summary>
    public class ColumnConfig : Config {
        /// <summary>
        /// 初始化列配置
        /// </summary>
        public ColumnConfig(){
        }

        /// <summary>
        /// 初始化列配置
        /// </summary>
        /// <param name="context">上下文</param>
        public ColumnConfig( Context context ) : base( context ) {
        }

        /// <summary>
        /// 表格标识
        /// </summary>
        public string TableId => Context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey )?.TableId;

        /// <summary>
        /// 列共享键
        /// </summary>
        public const string ColumnShareKey = "ColumnShare";

        /// <summary>
        /// 初始化共享实例
        /// </summary>
        public void InitShare() {
            Context.SetValueToItems( ColumnShareKey, new ColumnShareConfig() );
        }

        /// <summary>
        /// 是否自动创建列头
        /// </summary>
        public bool AutoCreateHeaderCell() {
            if( Context.GetValueFromItems<ColumnShareConfig>( ColumnShareKey )?.AutoCreateHeaderCell == false )
                return false;
            if( GetValue<TableColumnType?>( UiConst.Type ) == TableColumnType.Checkbox )
                return false;
            if( GetValue<TableColumnType?>( UiConst.Type ) == TableColumnType.Radio )
                return false;
            return true;
        }

        /// <summary>
        /// 是否自动创建单元格
        /// </summary>
        public bool AutoCreateCell() {
            if( Context.GetValueFromItems<ColumnShareConfig>( ColumnShareKey )?.AutoCreateCell == false )
                return false;
            if( GetValue<TableColumnType?>( UiConst.Type ) == TableColumnType.Checkbox )
                return false;
            if( GetValue<TableColumnType?>( UiConst.Type ) == TableColumnType.Radio )
                return false;
            return true;
        }
    }
}