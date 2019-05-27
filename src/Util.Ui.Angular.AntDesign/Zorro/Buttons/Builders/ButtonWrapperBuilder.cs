using Microsoft.AspNetCore.Html;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;

namespace Util.Ui.Zorro.Buttons.Builders {
    /// <summary>
    /// NgZorro按钮包装器生成器
    /// </summary>
    public class ButtonWrapperBuilder : TagBuilder {
        /// <summary>
        /// 模板生成器
        /// </summary>
        private readonly TemplateBuilder _templateBuilder;

        /// <summary>
        /// 初始化NgZorro按钮包装器生成器
        /// </summary>
        public ButtonWrapperBuilder() : base( "x-button" ) {
            _templateBuilder = new TemplateBuilder();
        }

        /// <summary>
        /// 添加文本
        /// </summary>
        /// <param name="text">文本</param>
        public void AddText( string text ) {
            AddAttribute( "text", text, false );
        }

        /// <summary>
        /// 添加文本
        /// </summary>
        /// <param name="text">文本</param>
        public void AddBindText( string text ) {
            AddAttribute( "[text]", text );
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="content">内容</param>
        public override TagBuilder AppendContent( IHtmlContent content ) {
            _templateBuilder.AppendContent( content );
            AddTemplateBuilder();
            return this;
        }

        /// <summary>
        /// 添加模板生成器
        /// </summary>
        private void AddTemplateBuilder() {
            if( this.HasInnerHtml )
                return;
            InnerHtml.AppendHtml( _templateBuilder );
        }
    }
}
