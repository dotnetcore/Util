using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Trees.Builders;

namespace Util.Ui.Zorro.Trees.Renders {
    /// <summary>
    /// 树形选择渲染器
    /// </summary>
    public class TreeSelectRender : TreeRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化树形包装器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeSelectRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new TreeSelectWrapperBuilder();
            Config( builder );
            ConfigName( builder );
            ConfigPlaceholder( builder );
            ConfigDisabled( builder );
            ConfigWidth( builder );
            ConfigModel( builder );
            ConfigRequired( builder );
            ConfigEvents( builder );
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
        /// 配置名称
        /// </summary>
        private void ConfigName( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Name, _config.GetValue( UiConst.Name ) );
            builder.AddAttribute( "[name]", _config.GetValue( AngularConst.BindName ) );
        }

        /// <summary>
        /// 配置占位提示
        /// </summary>
        private void ConfigPlaceholder( TagBuilder builder ) {
            builder.AddAttribute( "placeholder", _config.GetValue( UiConst.Placeholder ) );
            builder.AddAttribute( "[placeholder]", _config.GetValue( AngularConst.BindPlaceholder ) );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置宽度
        /// </summary>
        private void ConfigWidth( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Width, _config.GetValue( UiConst.Width ) );
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.NgModel( _config );
        }

        /// <summary>
        /// 配置必填项
        /// </summary>
        private void ConfigRequired( TagBuilder builder ) {
            builder.AddAttribute( "[required]", _config.GetBoolValue( UiConst.Required ) );
            builder.AddAttribute( "requiredMessage", _config.GetValue( UiConst.RequiredMessage ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onChange)", _config.GetValue( UiConst.OnChange ) );
            builder.AddAttribute( "(onExpand)", _config.GetValue( UiConst.OnExpand ) );
        }
    }
}
