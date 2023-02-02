using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders {
    /// <summary>
    /// 树形表头单元格标签生成器
    /// </summary>
    public class TreeTableHeadColumnBuilder : TableHeadColumnBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表头列共享配置
        /// </summary>
        private readonly TableHeadColumnShareConfig _shareConfig;

        /// <summary>
        /// 初始化树形表头单元格标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="shareConfig">表头列共享配置</param>
        public TreeTableHeadColumnBuilder( Config config, TableHeadColumnShareConfig shareConfig ) : base( config, shareConfig ) {
            _config = config;
            _shareConfig = shareConfig;
        }

        /// <inheritdoc />
        protected override void ConfigContent( Config config ) {
            if ( _shareConfig.IsFirst && _shareConfig.IsShowCheckbox )
                return;
            base.ConfigContent( config );
        }

        /// <summary>
        /// 添加表头单元格
        /// </summary>
        /// <param name="column">列</param>
        public override void AddColumn( ColumnInfo column ) {
            if ( column.IsFirst ) {
                AddFirstColumn( column );
            }
            else {
                Title( column.Title );
            }
            this.Width( column.Width );
        }

        /// <summary>
        /// 添加首列
        /// </summary>
        private void AddFirstColumn( ColumnInfo column ) {
            if ( _shareConfig.IsShowCheckbox ) {
                AddCheckBox( column.Title );
                return;
            }
            if ( _shareConfig.IsShowCheckbox == false && _shareConfig.IsShowRadio ) {
                AddRadio( column.Title );
                return;
            }
            if ( _shareConfig.IsShowLineNumber ) {
                AddLineNumber();
                return;
            }
            Title( column.Title );
        }

        /// <inheritdoc />
        protected override void AddCheckBox( string title = null ) {
            title = GetTitle( title );
            if ( title.IsEmpty() )
                title = _config.Content?.GetContent();
            var checkboxBuilder = new TreeTableMasterCheckBoxBuilder( _shareConfig.TableExtendId, title );
            SetContent( checkboxBuilder );
        }

        /// <summary>
        /// 获取标题
        /// </summary>
        /// <param name="title">标题</param>
        private string GetTitle( string title ) {
            title ??= _config.GetValue( UiConst.Title );
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n )
                return "{{" + $"'{title}'|i18n" + "}}";
            return title;
        }

        /// <inheritdoc />
        protected override void AddRadio( string title = null ) {
            title = GetTitle( title );
            if ( title.IsEmpty() )
                title = _config.Content?.GetContent();
            SetContent( title );
        }
    }
}