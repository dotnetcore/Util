using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Forms.Builders;

namespace Util.Ui.Zorro.Forms.Renders {
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
            ExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigName( builder );
            ConfigLabel( builder );
            ConfigDisabled( builder );
            ConfigModel( builder );
            ConfigIndeterminate( builder );
            ConfigEvents( builder );
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
            if( _config.Contains( UiConst.Label ) ) {
                builder.SetContent( _config.GetValue( UiConst.Label ) );
                return;
            }
            var bindLabel = _config.GetValue( AngularConst.BindLabel );
            if( bindLabel.IsEmpty() )
                return;
            builder.SetContent( $"{{{{{bindLabel}}}}}" );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "nzDisabled", _config.GetBoolValue( UiConst.Disabled ) );
            builder.AddAttribute( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.NgModel( _config, "ngModel" );
        }

        /// <summary>
        /// 配置中间状态
        /// </summary>
        private void ConfigIndeterminate( TagBuilder builder ) {
            builder.AddAttribute( "[nzIndeterminate]", _config.GetValue( UiConst.Indeterminate ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            ConfigOnChange( builder );
        }

        /// <summary>
        /// 配置变更事件
        /// </summary>
        protected virtual void ConfigOnChange( TagBuilder builder ) {
            builder.AddAttribute( "(nzOnChange)", _config.GetValue( UiConst.OnChange ) );
        }
    }
}
