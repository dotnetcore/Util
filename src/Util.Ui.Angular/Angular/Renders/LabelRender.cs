using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Enums;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;

namespace Util.Ui.Angular.Renders {
    /// <summary>
    /// 标签渲染器
    /// </summary>
    public class LabelRender : AngularRenderBase {
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
            ConfigByType( builder, text );
        }

        /// <summary>
        /// 根据类型配置
        /// </summary>
        private void ConfigByType( TagBuilder builder,string text ) {
            var type = _config.GetValue<LabelType?>( UiConst.Type );
            switch( type ) {
                case LabelType.Bool:
                    AddBoolType( builder, text );
                    return;
                case LabelType.Date:
                    AddDateType( builder, text );
                    return;
                default:
                    AddText( builder, text );
                    return;
            }
        }

        /// <summary>
        /// 添加布尔类型
        /// </summary>
        private void AddBoolType( TagBuilder builder, string text ) {
            var checkIconBuilder = new MaterialIconBuilder().SetContent( MaterialIcon.Check.Description() ).AddAttribute( "*ngIf", $"{text}" );
            builder.AppendContent( checkIconBuilder );
            var clearIconBuilder = new MaterialIconBuilder().SetContent( MaterialIcon.Clear.Description() ).AddAttribute( "*ngIf", $"!({text})" );
            builder.AppendContent( clearIconBuilder );
        }

        /// <summary>
        /// 添加日期类型
        /// </summary>
        private void AddDateType( TagBuilder builder, string text ) {
            var format = _config.GetValue( UiConst.DateFormat );
            if( string.IsNullOrWhiteSpace( format ) )
                format = "yyyy-MM-dd";
            builder.AppendContent( $"{{{{ {text} | date:\"{format}\" }}}}" );
        }

        /// <summary>
        /// 添加文本
        /// </summary>
        private void AddText( TagBuilder builder, string text ) {
            builder.SetContent( $"{{{{{text}}}}}" );
        }
    }
}