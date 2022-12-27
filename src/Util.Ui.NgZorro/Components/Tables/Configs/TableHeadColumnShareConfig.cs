namespace Util.Ui.NgZorro.Components.Tables.Configs {
    /// <summary>
    /// 表头列共享配置
    /// </summary>
    public class TableHeadColumnShareConfig {
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _tableShareConfig;

        /// <summary>
        /// 初始化表头列共享配置
        /// </summary>
        /// <param name="tableShareConfig">表格共享配置</param>
        public TableHeadColumnShareConfig( TableShareConfig tableShareConfig ) {
            _tableShareConfig = tableShareConfig;
        }

        /// <summary>
        /// 是否树形表格
        /// </summary>
        public bool IsTreeTable => _tableShareConfig.IsTreeTable;

        /// <summary>
        /// 表格扩展标识
        /// </summary>
        public string TableExtendId => _tableShareConfig.TableExtendId;

        /// <summary>
        /// 表格编辑扩展标识
        /// </summary>
        public string TableEditId => _tableShareConfig.TableEditId;

        /// <summary>
        /// 是否显示复选框
        /// </summary>
        public bool IsShowCheckbox => _tableShareConfig.IsShowCheckbox;

        /// <summary>
        /// 是否显示单选框
        /// </summary>
        public bool IsShowRadio => _tableShareConfig.IsShowRadio;

        /// <summary>
        /// 是否显示序号
        /// </summary>
        public bool IsShowLineNumber => _tableShareConfig.IsShowLineNumber;

        /// <summary>
        /// 是否自动创建表头单元格th
        /// </summary>
        public bool IsAutoCreateHeadColumn {
            get => _tableShareConfig.IsAutoCreateHeadColumn;
            set => _tableShareConfig.IsAutoCreateHeadColumn = value;
        }

        /// <summary>
        /// 是否第一列
        /// </summary>
        public bool IsFirst { get; set; }

        /// <summary>
        /// 设置第一列
        /// </summary>
        public void SetIsFirst() {
            if ( _tableShareConfig.HeadColumnNumber == 0 )
                IsFirst = true;
            _tableShareConfig.HeadColumnNumber++;
        }
    }
}
