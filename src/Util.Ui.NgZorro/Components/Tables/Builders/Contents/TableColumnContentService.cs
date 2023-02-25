using Microsoft.AspNetCore.Html;
using System;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 表格单元格内容服务
    /// </summary>
    public class TableColumnContentService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格列选择框创建服务
        /// </summary>
        private readonly ISelectCreateService _service;

        /// <summary>
        /// 初始化表格单元格内容
        /// </summary>
        /// <param name="builder">表格单元格标签生成器</param>
        /// <param name="service">表格列选择框创建服务</param>
        public TableColumnContentService( TableColumnBuilder builder, ISelectCreateService service ) {
            Builder = builder ?? throw new ArgumentNullException( nameof( builder ) );
            _service = service ?? throw new ArgumentNullException( nameof( service ) );
            _config = builder.GetConfig();
            ShareConfig = builder.GetTableColumnShareConfig();
        }

        /// <summary>
        /// 表格单元格标签生成器
        /// </summary>
        protected TableColumnBuilder Builder { get; }

        /// <summary>
        /// 表格列共享配置
        /// </summary>
        protected TableColumnShareConfig ShareConfig { get; }

        /// <summary>
        /// 配置内容
        /// </summary>
        public void Config() {
            var displayContent = GetDisplayContent();
            var loader = CreateContentLoader();
            loader.Load( Builder, displayContent );
        }

        /// <summary>
        /// 获取显示内容
        /// </summary>
        private IHtmlContent GetDisplayContent() {
            var content = GetTableColumnContent();
            return content.GetDisplayContent( Builder );
        }

        /// <summary>
        /// 获取表格单元格内容
        /// </summary>
        private ITableColumnContent GetTableColumnContent() {
            var type = _config.GetValue<TableColumnType?>( UiConst.Type );
            switch ( type ) {
                case TableColumnType.Bool:
                    return new TableColumnBoolContent();
                case TableColumnType.Enum:
                    return new TableColumnEnumContent();
                default:
                    return new TableColumnTextContent();
            }
        }

        /// <summary>
        /// 创建表格单元格内容加载器
        /// </summary>
        private ITableColumnContentLoader CreateContentLoader() {
            if ( IsEdit ) {
                if ( ShareConfig.IsFirst )
                    return new EditFirstColumnContentLoader( _service );
                return new EditContentLoader();
            }
            if ( ShareConfig.IsFirst )
                return new NoEditFirstColumnContentLoader( _service );
            return new NoEditContentLoader();
        }

        /// <summary>
        /// 是否编辑模式
        /// </summary>
        private bool IsEdit => _config.GetValue<bool>( UiConst.IsEdit );
    }
}
