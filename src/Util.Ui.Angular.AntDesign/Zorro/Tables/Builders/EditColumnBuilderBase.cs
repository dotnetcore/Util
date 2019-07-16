using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Extensions;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 编辑列生成器
    /// </summary>
    public abstract class EditColumnBuilderBase : TagBuilder, IInit {
        /// <summary>
        /// 初始化编辑列生成器
        /// </summary>
        /// <param name="editTableId">编辑表格标识</param>
        /// <param name="templateId">模板标识</param>
        /// <param name="column">列名</param>
        /// <param name="content">内容</param>
        /// <param name="isCreateDisplay">是否创建显示内容</param>
        /// <param name="isCreateControl">是否创建控件</param>
        protected EditColumnBuilderBase( string editTableId, string templateId, string column, TagHelperContent content,
            bool? isCreateDisplay,bool? isCreateControl ) : base( "td" ) {
            EditTableId = editTableId;
            TemplateId = templateId;
            Column = column;
            Content = content;
            if( isCreateDisplay == null || isCreateDisplay == true )
                IsCreateDisplay = true;
            if( isCreateControl == null || isCreateControl == true )
                IsCreateControl = true;
        }

        /// <summary>
        /// 编辑表格标识
        /// </summary>
        protected string EditTableId { get; }

        /// <summary>
        /// 模板标识
        /// </summary>
        protected string TemplateId { get; }

        /// <summary>
        /// 列名
        /// </summary>
        protected string Column { get; }

        /// <summary>
        /// 内容
        /// </summary>
        protected TagHelperContent Content { get; }

        /// <summary>
        /// 是否创建显示内容
        /// </summary>
        protected bool IsCreateDisplay { get; }

        /// <summary>
        /// 是否创建控件
        /// </summary>
        protected bool IsCreateControl { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init() {
            if( Column.IsEmpty() && Content.IsEmpty() )
                return;
            if( Content.IsEmpty() ) {
                InitColumn( this );
                return;
            }
            AppendContainerBuilder();
            AppendTemplateBuilder();
        }

        /// <summary>
        /// 添加容器生成器
        /// </summary>
        private void AppendContainerBuilder() {
            if ( IsCreateDisplay == false )
                return;
            if( Column.IsEmpty() )
                return;
            var containerBuilder = CreateContainerBuilder();
            AppendContent( containerBuilder );
            InitColumn( containerBuilder );
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        private ContainerBuilder CreateContainerBuilder() {
            return CreateContainerBuilder( EditTableId, TemplateId );
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        /// <param name="editTableId">编辑表格标识</param>
        /// <param name="templateId">模板标识</param>
        public static ContainerBuilder CreateContainerBuilder( string editTableId, string templateId ) {
            var builder = new ContainerBuilder();
            if( editTableId.IsEmpty() || templateId.IsEmpty() )
                return builder;
            builder.NgIf( $"{editTableId}.editId !== row.id;else {templateId}" );
            return builder;
        }

        /// <summary>
        /// 初始化列
        /// </summary>
        protected abstract void InitColumn( TagBuilder builder );

        /// <summary>
        /// 添加模板生成器
        /// </summary>
        private void AppendTemplateBuilder() {
            if( Column.IsEmpty() || IsCreateControl == false ) {
                AppendContent( Content );
                return;
            }
            var templateBuilder = CreateTemplateBuilder();
            AppendContent( templateBuilder );
            templateBuilder.AppendContent( Content );
        }

        /// <summary>
        /// 创建模板生成器
        /// </summary>
        private TemplateBuilder CreateTemplateBuilder() {
            var builder = new TemplateBuilder();
            builder.AddAttribute( $"#{TemplateId}" );
            return builder;
        }
    }
}
