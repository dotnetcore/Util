using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Enums;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Descriptions.Builders;
using Util.Ui.Zorro.Icons.Builders;

namespace Util.Ui.Zorro.Descriptions.Renders {
    /// <summary>
    /// 描述列表项渲染器
    /// </summary>
    public class DescriptionItemRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化描述列表项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DescriptionItemRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new DescriptionItemBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        protected void ResolveExpression() {
            if( _config.Contains( UiConst.For ) == false )
                return;
            var expression = _config.GetValue<ModelExpression>( UiConst.For );
            LabelExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            Init();
            ConfigId( builder );
            ConfigSpan( builder );
            ConfigLabel( builder );
            ConfigValue( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            if( _config.Contains( UiConst.Model ) )
                _config.SetAttribute( AngularConst.BindValue, _config.GetValue( UiConst.Model ), false );
        }

        /// <summary>
        /// 配置列跨度
        /// </summary>
        private void ConfigSpan( TagBuilder builder ) {
            builder.AddAttribute( "[nzSpan]", _config.GetValue( UiConst.Span ) );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigLabel( TagBuilder builder ) {
            builder.AddAttribute( "nzTitle", _config.GetValue( UiConst.Label ) );
        }

        /// <summary>
        /// 配置值
        /// </summary>
        private void ConfigValue( TagBuilder builder ) {
            if( _config.Content.IsEmpty() == false )
                return;
            var value = _config.GetValue( UiConst.Value );
            if ( value.IsEmpty() == false ) {
                builder.SetContent( value );
                return;
            }
            value = _config.GetValue( AngularConst.BindValue );
            if( value.IsEmpty() )
                return;
            ConfigByType( builder, value );
        }

        /// <summary>
        /// 根据类型配置
        /// </summary>
        private void ConfigByType( TagBuilder builder, string value ) {
            var type = _config.GetValue<LabelType?>( UiConst.Type );
            switch( type ) {
                case LabelType.Bool:
                    AddBoolType( builder, value );
                    return;
                case LabelType.Date:
                    AddDateType( builder, value );
                    return;
                default:
                    AddValue( builder, value );
                    return;
            }
        }

        /// <summary>
        /// 添加布尔值
        /// </summary>
        private void AddBoolType( TagBuilder builder, string value ) {
            var checkIconBuilder = new IconBuilder().AddType( AntDesignIcon.Check.Description() ).AddAttribute( "*ngIf", $"{value}" );
            builder.AppendContent( checkIconBuilder );
            var clearIconBuilder = new IconBuilder().AddType( AntDesignIcon.Close.Description() ).AddAttribute( "*ngIf", $"!({value})" );
            builder.AppendContent( clearIconBuilder );
        }

        /// <summary>
        /// 添加日期值
        /// </summary>
        private void AddDateType( TagBuilder builder, string text ) {
            var format = _config.GetValue( UiConst.DateFormat );
            if( string.IsNullOrWhiteSpace( format ) )
                format = "yyyy-MM-dd";
            builder.AppendContent( $"{{{{ {text} | date:\"{format}\" }}}}" );
        }

        /// <summary>
        /// 添加文本值
        /// </summary>
        private void AddValue( TagBuilder builder, string value ) {
            builder.SetContent( $"{{{{{value}}}}}" );
        }
    }
}