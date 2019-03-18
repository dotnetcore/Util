using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Menus.Builders;
using Util.Ui.Material.Menus.Configs;

namespace Util.Ui.Material.Menus.Renders {
    /// <summary>
    /// 菜单渲染器
    /// </summary>
    public class MenuRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly MenuConfig _config;

        /// <summary>
        /// 初始化菜单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuRender( MenuConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            var builder = (MenuBuilder)Builder;
            builder.TemplateBuilder.SetContent( _config.Content );
            base.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染起始标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public override void RenderStartTag( TextWriter writer ) {
            var builder = (MenuBuilder)Builder;
            builder.RenderStartTag( writer );
            builder.TemplateBuilder.RenderStartTag( writer );
        }

        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public override void RenderEndTag( TextWriter writer ) {
            var builder = (MenuBuilder)Builder;
            builder.TemplateBuilder.RenderEndTag( writer );
            builder.RenderEndTag( writer );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new MenuBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( MenuBuilder builder ) {
            ConfigId( builder );
            ConfigPosition( builder );
            ConfigOverlap( builder );
            ConfigItems( builder );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            if( _config.Contains( UiConst.Id ) ) {
                builder.AddAttribute( $"#{_config.GetValue( UiConst.Id )}", "matMenu" );
                return;
            }
            builder.AddAttribute( "#menu", "matMenu" );
        }

        /// <summary>
        /// 配置位置
        /// </summary>
        private void ConfigPosition( TagBuilder builder ) {
            builder.AddAttribute( "xPosition", _config.GetValue<XPosition?>( UiConst.XPosition )?.Description() );
            builder.AddAttribute( "yPosition", _config.GetValue<YPosition?>( UiConst.YPosition )?.Description() );
        }

        /// <summary>
        /// 配置重叠
        /// </summary>
        private void ConfigOverlap( TagBuilder builder ) {
            builder.AddAttribute( "[overlapTrigger]", _config.GetBoolValue( UiConst.Overlap ) );
        }

        /// <summary>
        /// 配置菜单项
        /// </summary>
        private void ConfigItems( MenuBuilder builder ) {
            _config.Data?.Items.ForEach( item => {
                builder.TemplateBuilder.AppendContent( new MenuItem( item ) );
            } );
        }
    }
}
