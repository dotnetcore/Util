using Util.Ui.Angular.Builders;
using Util.Ui.Extensions;

namespace Util.Ui.Zorro.TreeTables.Builders {
    /// <summary>
    /// 树形表格列td生成器
    /// </summary>
    public class TreeTableColumnBuilder : Util.Ui.Zorro.Tables.Builders.TableColumnBuilder {
        /// <summary>
        /// 设置列
        /// </summary>
        /// <param name="treeTableWrapperId">树形表格包装器标识</param>
        /// <param name="column">列</param>
        /// <param name="indentSize">缩进大小</param>
        public void SetColumn( string treeTableWrapperId, string column, int indentSize ) {
            AddAttribute( "[nzIndentSize]", $"row.level*{indentSize}" );
            AddAttribute( "[nzShowExpand]", $"!{treeTableWrapperId}.isLeaf(row)" );
            AddAttribute( "[nzExpand]", $"{treeTableWrapperId}.isExpand(row)" );
            AddAttribute( "(nzExpandChange)", $"{treeTableWrapperId}.collapse(row,$event)" );
            AppendContent( new CheckBoxBuilder( treeTableWrapperId, column ) );
            AppendContent( CreateContainerBuilder( treeTableWrapperId, column ) );
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        private ContainerBuilder CreateContainerBuilder( string treeTableWrapperId, string column ) {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.NgIf( $"!{treeTableWrapperId}.showCheckbox" );
            containerBuilder.AppendContent( $"{{{{{column}}}}}" );
            return containerBuilder;
        }
    }
}
