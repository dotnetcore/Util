using Util.Ui.Builders;
using Util.Ui.Zorro.Tables.Builders;
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
            return builder;
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        protected override void AddHead( TagBuilder tableBuilder ) {
            if( _config.Columns.Count == 0 || _config.AutoCreateHead == false )
                return;
            var headBuilder = new TableHeadBuilder();
            tableBuilder.AppendContent( headBuilder );
            AddSortChange( headBuilder );
            var rowBuilder = new TableRowBuilder();
            AddHeadColumns( rowBuilder );
            headBuilder.AppendContent( rowBuilder );
        }

        /// <summary>
        /// 添加标题列
        /// </summary>
        private void AddHeadColumns( TableRowBuilder rowBuilder ) {
            for ( int i = 0; i < _config.Columns.Count; i++ ) {
                var column = _config.Columns[i];
                var headColumnBuilder = new TableHeadColumnBuilder();
                headColumnBuilder.AddWidth( column.Width );
                headColumnBuilder.Title( column.Title );
                headColumnBuilder.AddSort( column.GetSortKey() );
                rowBuilder.AppendContent( headColumnBuilder );
            }
        }
    }
}
