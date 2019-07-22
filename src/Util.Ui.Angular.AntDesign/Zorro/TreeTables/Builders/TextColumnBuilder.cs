using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Extensions;

namespace Util.Ui.Zorro.TreeTables.Builders {
    /// <summary>
    /// 树形表格文本列生成器
    /// </summary>
    public class TextColumnBuilder : TagBuilder, IInit {
        /// <summary>
        /// 初始化树形表格文本列生成器
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="trancateLength">截断保留长度</param>
        /// <param name="content">内容</param>
        /// <param name="isAddCheckbox">是否添加复选框</param>
        /// <param name="tableWrapperId">表格包装器标识</param>
        /// <param name="indentSize">缩进大小</param>
        public TextColumnBuilder( string column, int? trancateLength, TagHelperContent content,bool isAddCheckbox,
            string tableWrapperId,int indentSize = 20 ) : base( "td" ) {
            Column = column;
            TrancateLength = trancateLength;
            Content = content;
            IsAddCheckbox = isAddCheckbox;
            TableWrapperId = tableWrapperId;
            IndentSize = indentSize;
        }

        /// <summary>
        /// 列名
        /// </summary>
        protected string Column { get; }

        /// <summary>
        /// 截断保留长度
        /// </summary>
        protected int? TrancateLength { get; }

        /// <summary>
        /// 内容
        /// </summary>
        protected TagHelperContent Content { get; }

        /// <summary>
        /// 是否添加复选框
        /// </summary>
        protected bool IsAddCheckbox { get; }

        /// <summary>
        /// 表格包装器标识
        /// </summary>
        protected string TableWrapperId { get; }

        /// <summary>
        /// 缩进大小
        /// </summary>
        protected int IndentSize { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init() {
            if ( IsAddCheckbox ) {
                CreateCheckboxColumn( $"row.{Column}" );
                return;
            }
            if( Content.IsEmpty() == false ) {
                base.AppendContent( Content );
                return;
            }
            if( Column.IsEmpty() )
                return;
            Util.Ui.Zorro.Tables.Builders.TextColumnBuilder.InitColumn( this, Column, TrancateLength );
        }

        /// <summary>
        /// 设置列
        /// </summary>
        private void CreateCheckboxColumn( string column ) {
            AddAttribute( "[nzIndentSize]", $"row.level*{IndentSize}" );
            AddAttribute( "[nzShowExpand]", $"!{TableWrapperId}.isLeaf(row)" );
            AddAttribute( "[nzExpand]", $"{TableWrapperId}.isExpand(row)" );
            AddAttribute( "(nzExpandChange)", $"{TableWrapperId}.collapse(row,$event)" );
            AppendContent( new CheckBoxBuilder( TableWrapperId, column ) );
            AppendContent( new RadioBuilder( TableWrapperId, column ) );
            AppendContent( CreateContainerBuilder( TableWrapperId, column ) );
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        private ContainerBuilder CreateContainerBuilder( string treeTableWrapperId, string column ) {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.NgIf( $"{treeTableWrapperId}.isShowText(row)" );
            containerBuilder.AppendContent( $"{{{{{column}}}}}" );
            return containerBuilder;
        }
    }
}
