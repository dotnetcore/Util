using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表格列服务
    /// </summary>
    public class TableColumnService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格列共享配置
        /// </summary>
        private TableColumnShareConfig _shareConfig;

        /// <summary>
        /// 初始化表格列服务
        /// </summary>
        /// <param name="config">配置</param>
        public TableColumnService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            CreateTableColumnShareConfig();
            EnableEllipsis();
            LoadExpression();
            AddToColumns();
        }

        /// <summary>
        /// 创建表格列共享配置
        /// </summary>
        private void CreateTableColumnShareConfig() {
            _shareConfig = new TableColumnShareConfig( GetTableShareConfig() );
            _config.SetValueToItems( _shareConfig );
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        private TableShareConfig GetTableShareConfig() {
            return _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 启用自动省略
        /// </summary>
        private void EnableEllipsis() {
            var result = _config.GetValue<bool>( UiConst.Ellipsis );
            if( result )
                _shareConfig.EnableEllipsis();
        }

        /// <summary>
        /// 加载表达式
        /// </summary>
        private void LoadExpression() {
            var expressionLoader = new TableColumnExpressionLoader();
            expressionLoader.Load( _config );
        }

        /// <summary>
        /// 将当前列添加到表格列集合中
        /// </summary>
        private void AddToColumns() {
            _shareConfig.AddColumn( GetColumnInfo() );
        }

        /// <summary>
        /// 获取列信息
        /// </summary>
        private ColumnInfo GetColumnInfo() {
            var type = GetColumnType();
            var result = new ColumnInfo {
                Title = GetTitle( type ),
                Column = GetColumn(),
                Width = GetWidth(type),
                IsLineNumber = type == TableColumnType.LineNumber,
                IsCheckbox = type == TableColumnType.Checkbox
            };
            return result;
        }

        /// <summary>
        /// 获取列类型
        /// </summary>
        private TableColumnType? GetColumnType() {
            return _config.GetValue<TableColumnType?>( UiConst.Type );
        }

        /// <summary>
        /// 获取标题
        /// </summary>
        private string GetTitle( TableColumnType? type ) {
            var result = _config.GetValue( UiConst.Title );
            if ( result.IsEmpty() == false )
                return result;
            return type == TableColumnType.LineNumber ? _shareConfig.GetLineNumberTitle() : null;
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        private string GetColumn() {
            return _config.GetValue( UiConst.Column );
        }

        /// <summary>
        /// 获取宽度
        /// </summary>
        private string GetWidth( TableColumnType? type ) {
            var result = _config.GetValue( UiConst.Width );
            if ( result.IsEmpty() == false )
                return result;
            if ( type == TableColumnType.LineNumber )
                return $"{_shareConfig.TableExtendId}.config.table.lineNumberWidth";
            if ( type == TableColumnType.Checkbox )
                return $"{_shareConfig.TableExtendId}.config.table.checkboxWidth";
            return null;
        }
    }
}
