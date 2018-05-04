using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Angular.Renders {
    /// <summary>
    /// 标签渲染器
    /// </summary>
    public class LabelRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化标签渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public LabelRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new SpanBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        private void ResolveExpression() {
            if( _config.Contains( UiConst.For ) == false )
                return;
            var expression = _config.GetValue<ModelExpression>( UiConst.For );
            LabelExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigText( builder );
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            var text = _config.GetValue( UiConst.Text );
            if ( text.IsEmpty() == false ) {
                builder.SetContent( text );
                return;
            }
            text = _config.GetValue( AngularConst.BindText );
            if ( text.IsEmpty() )
                return;
            builder.SetContent( $"{{{{{text}}}}}" );
        }
    }
}