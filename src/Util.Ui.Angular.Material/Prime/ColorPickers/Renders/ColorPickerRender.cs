using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Prime.ColorPickers.Builders;
using Util.Ui.Prime.ColorPickers.Resolvers;

namespace Util.Ui.Prime.ColorPickers.Renders {
    /// <summary>
    /// 颜色选择器渲染器
    /// </summary>
    public class ColorPickerRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化颜色选择器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColorPickerRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new ColorPickerBuilder();
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
            ColorPickerExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigName( builder );
            ConfigModel( builder );
            ConfigDisabled( builder );
            ConfigInline( builder );
            ConfigEvents( builder );
            ConfigStandalone( builder );
        }

        /// <summary>
        /// 配置名称
        /// </summary>
        private void ConfigName( TagBuilder builder ) {
            builder.AddAttribute( "name", _config.GetValue( UiConst.Name ) );
            builder.AddAttribute( "[name]", _config.GetValue( AngularConst.BindName ) );
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.AddAttribute( "[(ngModel)]", _config.GetValue( UiConst.Model ) );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置内联
        /// </summary>
        private void ConfigInline( TagBuilder builder ) {
            builder.AddAttribute( "inline", _config.GetBoolValue( UiConst.Inline ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onChange)", _config.GetValue( UiConst.OnChange ) );
        }

        /// <summary>
        /// 配置独立
        /// </summary>
        private void ConfigStandalone( TagBuilder builder ) {
            if( _config.GetValue<bool>( UiConst.Standalone ) )
                builder.AddAttribute( "[ngModelOptions]", "{standalone: true}" );
        }
    }
}