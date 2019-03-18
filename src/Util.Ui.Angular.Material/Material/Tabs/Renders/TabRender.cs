using System.IO;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Icons.Builders;
using Util.Ui.Material.Tabs.Builders;

namespace Util.Ui.Material.Tabs.Renders {
    /// <summary>
    /// 选项卡渲染器
    /// </summary>
    public class TabRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化选项卡渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TabRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 渲染起始标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public override void RenderStartTag( TextWriter writer ) {
            var builder = (TabBuilder)Builder;
            builder.RenderStartTag( writer );
            if( Builder.HasInnerHtml )
                Builder.RenderBody( writer );
            if( _config.GetValue<bool>( UiConst.LazyLoad ) )
                builder.ContenTemplateBuilder.RenderStartTag( writer );
        }

        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public override void RenderEndTag( TextWriter writer ) {
            var builder = (TabBuilder)Builder;
            if( _config.GetValue<bool>( UiConst.LazyLoad ) )
                builder.ContenTemplateBuilder.RenderEndTag( writer );
            builder.RenderEndTag( writer );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TabBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TabBuilder builder ) {
            ConfigId( builder );
            ConfigCaption( builder );
            ConfigDisabled( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigCaption( TabBuilder builder ) {
            ConfigMaterialIcon( builder.HeaderTemplateBuilder );
            ConfigFontAwesomeIcon( builder.HeaderTemplateBuilder );
            ConfigLabel( builder.HeaderTemplateBuilder );
            builder.AppendContent( builder.HeaderTemplateBuilder );
        }

        /// <summary>
        /// 配置Material图标
        /// </summary>
        private void ConfigMaterialIcon( TagBuilder builder ) {
            if( _config.Contains( UiConst.MaterialIcon ) == false )
                return;
            var iconBuilder = new MaterialIconBuilder();
            iconBuilder.SetIcon( _config );
            builder.AppendContent( iconBuilder );
        }

        /// <summary>
        /// 配置FontAwesome图标
        /// </summary>
        private void ConfigFontAwesomeIcon( TagBuilder builder ) {
            if( _config.Contains( UiConst.FontAwesomeIcon ) == false )
                return;
            var iconBuilder = new FontAwesomeIconBuilder();
            iconBuilder.SetIcon( _config );
            builder.AppendContent( iconBuilder );
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        private void ConfigLabel( TagBuilder builder ) {
            if( _config.Contains( UiConst.Label ) == false )
                return;
            builder.AppendContent( _config.GetValue( UiConst.Label ) );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private void ConfigContent( TabBuilder builder ) {
            if( _config.Content == null || _config.Content.IsEmptyOrWhiteSpace )
                return;
            if ( _config.GetValue<bool>( UiConst.LazyLoad ) == false ) {
                builder.AppendContent( _config.Content );
                return;
            }
            builder.ContenTemplateBuilder.AppendContent( _config.Content );
            builder.AppendContent( builder.ContenTemplateBuilder );
        }
    }
}