using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Enums;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Tables.Configs {
    /// <summary>
    /// 表格列配置
    /// </summary>
    public class TableColumnConfig : Config {
        /// <summary>
        /// 初始化表格列配置
        /// </summary>
        public TableColumnConfig(){
        }

        /// <summary>
        /// 初始化表格列配置
        /// </summary>
        /// <param name="context">上下文</param>
        public TableColumnConfig( Context context ) : base( context ) {
        }

        /// <summary>
        /// 表格标识
        /// </summary>
        public string TableId => Context.GetValueFromItems<string>( MaterialConst.TableId );

        /// <summary>
        /// 是否自动创建单元格定义
        /// </summary>
        public bool AutoCreateCell() {
            if ( Content != null && Content.IsEmptyOrWhiteSpace == false )
                return false;
            if( GetValue<TableColumnType?>( UiConst.Type ) == TableColumnType.Checkbox )
                return false;
            return true;
        }
    }
}