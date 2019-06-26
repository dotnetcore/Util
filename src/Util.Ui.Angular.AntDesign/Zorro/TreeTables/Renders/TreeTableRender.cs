using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Tables.Configs;
using Util.Ui.Zorro.Tables.Renders;
using Util.Ui.Zorro.TreeTables.Builders;
using TableHeadColumnBuilder = Util.Ui.Zorro.Tables.Builders.TableHeadColumnBuilder;

namespace Util.Ui.Zorro.TreeTables.Renders {
    /// <summary>
    /// 树形表格渲染器
    /// </summary>
    public class TreeTableRender : TableRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly TableConfig _config;

        /// <summary>
        /// 初始化树形表格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeTableRender( TableConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TreeTableWrapperBuilder();
            Config( builder );
            ConfigExpandAll( builder );
            ConfigShowCheckbox( builder );
            ConfigCheckLeafOnly( builder );
            ConfigEvents( builder );
            return builder;
        }

        /// <summary>
        /// 配置展开
        /// </summary>
        private void ConfigExpandAll( TagBuilder builder ) {
            builder.AddAttribute( "[expandAll]", _config.GetBoolValue( UiConst.ExpandAll ) );
        }

        /// <summary>
        /// 配置显示复选框
        /// </summary>
        private void ConfigShowCheckbox( TagBuilder builder ) {
            builder.AddAttribute( "[showCheckbox]", _config.GetBoolValue( UiConst.ShowCheckbox ) );
        }

        /// <summary>
        /// 配置选择叶节点
        /// </summary>
        private void ConfigCheckLeafOnly( TagBuilder builder ) {
            builder.AddAttribute( "[checkLeafOnly]", _config.GetValue( UiConst.CheckLeafOnly ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onExpand)", _config.GetValue( UiConst.OnExpand ) );
        }

        /// <summary>
        /// 添加标题列
        /// </summary>
        protected override void AddHeadColumns( TableRowBuilder rowBuilder ) {
            for ( int i = 0; i < _config.Columns.Count; i++ ) {
                var headColumnBuilder = new TableHeadColumnBuilder();
                var column = _config.Columns[i];
                if ( i == 0 )
                    AddCheckboxColumn( headColumnBuilder, column );
                else
                    AddColumn( headColumnBuilder, column );
                rowBuilder.AppendContent( headColumnBuilder );
            }
        }

        /// <summary>
        /// 添加复选框列
        /// </summary>
        private void AddCheckboxColumn( TableHeadColumnBuilder headColumnBuilder, ColumnInfo column ) {
            AddCheckBoxBuilder( headColumnBuilder, column );
            AddSpanBuilder( headColumnBuilder, column );
        }

        /// <summary>
        /// 添加标题复选框生成器
        /// </summary>
        private void AddCheckBoxBuilder( TableHeadColumnBuilder headColumnBuilder, ColumnInfo column ) {
            var checkBoxBuilder = new MasterCheckBoxBuilder( GetWrapperId(), column.Title );
            headColumnBuilder.AppendContent( checkBoxBuilder );
        }

        /// <summary>
        /// 添加标签生成器
        /// </summary>
        private void AddSpanBuilder( TableHeadColumnBuilder headColumnBuilder, ColumnInfo column ) {
            var spanBuilder = new SpanBuilder();
            spanBuilder.AddAttribute( "*ngIf", $"!{GetWrapperId()}.isShowCheckbox()" );
            spanBuilder.SetContent( column.Title );
            headColumnBuilder.AppendContent( spanBuilder );
        }

        /// <summary>
        /// 添加复选框列
        /// </summary>
        private void AddColumn( TableHeadColumnBuilder headColumnBuilder, ColumnInfo column ) {
            headColumnBuilder.AddWidth( column.Width );
            headColumnBuilder.Title( column.Title );
            headColumnBuilder.AddSort( column.GetSortKey() );
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        protected override void AddBody( TableBodyBuilder tableBodyBuilder ) {
            tableBodyBuilder.AppendContent( CreateContainerBuilder() );
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        private ContainerBuilder CreateContainerBuilder() {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.NgFor( $"let row of {_config.Id}.data" );
            containerBuilder.AppendContent( CreateRowBuilder() );
            return containerBuilder;
        }

        /// <summary>
        /// 创建行生成器
        /// </summary>
        private TableRowBuilder CreateRowBuilder() {
            var rowBuilder = new TableRowBuilder();
            rowBuilder.NgIf( $"{GetWrapperId()}.isShow(row)" );
            rowBuilder.AppendContent( _config.Content );
            return rowBuilder;
        }
    }
}
