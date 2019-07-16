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
        /// 表格包装器标识
        /// </summary>
        public string WrapperId => GetShareConfig().TableWrapperId;

        /// <summary>
        /// 获取共享配置
        /// </summary>
        private TableShareConfig GetShareConfig() {
            return Context.GetValueFromItems<TableShareConfig>();
        }

        /// <summary>
        /// 表格标识
        /// </summary>
        public string Id => GetShareConfig().TableId;

        /// <summary>
        /// 编辑表格标识
        /// </summary>
        public string EditTableId => GetShareConfig().EditTableId;

        /// <summary>
        /// 表格行标识
        /// </summary>
        public string RowId => GetShareConfig().RowId;

        /// <summary>
        /// 标题集合
        /// </summary>
        public List<ColumnInfo> Columns => GetShareConfig().Columns;

        /// <summary>
        /// 是否自动创建行
        /// </summary>
        public bool AutoCreateRow => GetShareConfig().AutoCreateRow;

        /// <summary>
        /// 是否自动创建表头
        /// </summary>
        public bool AutoCreateHead => GetShareConfig().AutoCreateHead;

        /// <summary>
        /// 是否排序
        /// </summary>
        public bool IsSort => GetShareConfig().IsSort;

        /// <summary>
        /// 是否支持表格编辑
        /// </summary>
        public bool IsEdit => GetShareConfig().IsEdit;
    }
}