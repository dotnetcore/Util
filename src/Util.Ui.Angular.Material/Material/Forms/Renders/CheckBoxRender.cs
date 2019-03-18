using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.Builders;
using Util.Ui.Material.Forms.Resolvers;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 复选框渲染器
    /// </summary>
    public class CheckBoxRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化复选框渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CheckBoxRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new CheckBoxBuilder();
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
            CheckBoxExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigName( builder );
            ConfigLabel( builder );
            ConfigDisabled( builder );
            ConfigColor( builder );
            ConfigModel( builder );
            ConfigIndeterminate( builder );
            ConfigRequired( builder );
            ConfigEvents( builder );
            ConfigChecked( builder );
            ConfigStandalone( builder );
        }

        /// <summary>
        /// 配置名称
        /// </summary>
        private void ConfigName( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Name, _config.GetValue( UiConst.Name ) );
            builder.AddAttribute( "[name]", _config.GetValue( AngularConst.BindName ) );
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        private void ConfigLabel( TagBuilder builder ) {
            builder.SetContent( _config.GetValue( UiConst.Label ) );
            var bindLabel = _config.GetValue( AngularConst.BindLabel );
            if( !bindLabel.IsEmpty() )
                builder.SetContent( $"{{{{{bindLabel}}}}}" );
            builder.AddAttribute( "labelPosition", _config.GetValue<XPosition?>( UiConst.Position )?.Description() );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        private void ConfigColor( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Color, _config.GetValue( UiConst.Color )?.ToLower() );
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.AddAttribute( "[(ngModel)]", _config.GetValue( UiConst.Model ) );
        }

        /// <summary>
        /// 配置不确定样式
        /// </summary>
        private void ConfigIndeterminate( TagBuilder builder ) {
            builder.AddAttribute( "[indeterminate]", _config.GetValue( UiConst.Indeterminate ) );
        }

        /// <summary>
        /// 配置必填项
        /// </summary>
        private void ConfigRequired( TagBuilder builder ) {
            builder.AddAttribute( "[required]", _config.GetBoolValue( UiConst.Required ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(change)", _config.GetValue( UiConst.OnChange ) );
        }

        /// <summary>
        /// 配置选中
        /// </summary>
        private void ConfigChecked( TagBuilder builder ) {
            builder.AddAttribute( "[checked]", _config.GetValue( UiConst.Checked ) );
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
