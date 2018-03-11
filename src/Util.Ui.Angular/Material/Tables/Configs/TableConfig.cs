using System.Collections.Generic;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Tables.Configs {
    /// <summary>
    /// 表格配置
    /// </summary>
    public class TableConfig : Config {
        /// <summary>
        /// 初始化表格配置
        /// </summary>
        /// <param name="context">上下文</param>
        public TableConfig( Context context ) : base( context ) {
        }

        /// <summary>
        /// 表格共享键
        /// </summary>
        public const string TableShareKey = "TableShare";

        /// <summary>
        /// 表格标识
        /// </summary>
        public string Id => Context.GetValueFromItems<TableShareConfig>( TableShareKey ).TableId;

        /// <summary>
        /// 列集合
        /// </summary>
        public List<string> Columns => Context.GetValueFromItems<TableShareConfig>( TableShareKey ).Columns;

        /// <summary>
        /// 是否自动创建行
        /// </summary>
        public bool AutoCreateRow => Context.GetValueFromItems<TableShareConfig>( TableShareKey ).AutoCreateRow;
    }
}