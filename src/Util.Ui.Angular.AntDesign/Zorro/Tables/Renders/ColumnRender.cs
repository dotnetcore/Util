using Util.Ui.Angular.Base;
using Util.Ui.Angular.Enums;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables.Builders;
using Util.Ui.Zorro.Tables.Configs;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 列渲染器
    /// </summary>
    public class ColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = CreateColumnBuilder();
            if( builder is IInit result )
                result.Init();
            ConfigId( builder );
            ConfigSpan( builder );
            return builder;
        }

        /// <summary>
        /// 创建列生成器
        /// </summary>
        protected virtual TagBuilder CreateColumnBuilder() {
            var shareConfig = _config.GetValueFromItems<ColumnShareConfig>();
            var type = _config.GetValue<TableColumnType?>( UiConst.Type );
            var tableId = shareConfig?.TableId;
            var editTableId = shareConfig?.EditTableId;
            var column = shareConfig?.Column;
            var templateId = shareConfig?.TemplateId;
            var format = _config.GetValue( UiConst.DateFormat );
            var length = _config.GetValue<int?>( UiConst.Truncate );
            var isEdit = (shareConfig?.IsEdit).SafeValue();
            switch( type ) {
                case TableColumnType.LineNumber:
                    return new LineNumberColumnBuilder();
                case TableColumnType.Checkbox:
                    return new CheckboxColumnBuilder( tableId );
                case TableColumnType.Bool:
                    return new BoolColumnBuilder( column, _config.Content );
                case TableColumnType.Date:
                    return new DateColumnBuilder( column, format, _config.Content );
                default:
                    if( isEdit )
                        return new TextEditColumnBuilder( editTableId, templateId, column, length, _config.Content, shareConfig?.IsCreateDisplay, shareConfig?.IsCreateControl );
                    return new TextColumnBuilder( column, length, _config.Content );
            }
        }

        /// <summary>
        /// 配置跨度
        /// </summary>
        protected void ConfigSpan( TagBuilder builder ) {
            builder.AddAttribute( "[attr.colspan]", _config.GetValue( UiConst.Colspan ) );
            builder.AddAttribute( "[attr.rowspan]", _config.GetValue( UiConst.Rowspan ) );
        }
    }
}