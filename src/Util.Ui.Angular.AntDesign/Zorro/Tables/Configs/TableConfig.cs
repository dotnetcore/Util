using System.Collections.Generic;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.TagHelpers;

namespace Util.Ui.Zorro.Tables.Configs {
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
        /// 序号宽度
        /// </summary>
        public static string LineNumberWidth { get; set; } = "70";

        /// <summary>
        /// 复选框宽度
        /// </summary>
        public static string CheckboxWidth { get; set; } = "30";

        /// <summary>
        /// 分页总量模板
        /// </summary>
        public static string TotalTemplate { get; set; } = "{{ range[0] }}-{{ range[1] }} 共 {{ total }} 条";

        /// <summary>
        /// 表格共享键
        /// </summary>
        public const string TableShareKey = "TableShare";

        /// <summary>
        /// 表格包装器标识
        /// </summary>
        public string WrapperId => Context.GetValueFromItems<TableShareConfig>( TableShareKey ).TableWrapperId;

        /// <summary>
        /// 表格标识
        /// </summary>
        public string Id => Context.GetValueFromItems<TableShareConfig>( TableShareKey ).TableId;

        /// <summary>
        /// 标题集合
        /// </summary>
        public List<ColumnInfo> Columns => Context.GetValueFromItems<TableShareConfig>( TableShareKey ).Columns;

        /// <summary>
        /// 是否自动创建行
        /// </summary>
        public bool AutoCreateRow => Context.GetValueFromItems<TableShareConfig>( TableShareKey ).AutoCreateRow;

        /// <summary>
        /// 是否自动创建表头
        /// </summary>
        public bool AutoCreateHead => Context.GetValueFromItems<TableShareConfig>( TableShareKey ).AutoCreateHead;

        /// <summary>
        /// 是否排序
        /// </summary>
        public bool IsSort => Context.GetValueFromItems<TableShareConfig>( TableShareKey ).IsSort;
    }
}