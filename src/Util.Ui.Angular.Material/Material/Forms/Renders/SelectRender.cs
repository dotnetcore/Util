using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Angular.Forms.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Forms.Builders;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 下拉列表渲染器
    /// </summary>
    public class SelectRender : FormControlRenderBase {
        /// <summary>
        /// 下拉列表配置
        /// </summary>
        private readonly SelectConfig _config;

        /// <summary>
        /// 初始化下拉列表渲染器
        /// </summary>
        /// <param name="config">下拉列表配置</param>
        public SelectRender( SelectConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new SelectWrapperBuilder();
            base.Config( builder );
            ConfigSelect( builder );
            return builder;
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        private void ResolveExpression() {
            if( _config.Contains( UiConst.For ) == false )
                return;
            var expression = _config.GetValue<ModelExpression>( UiConst.For );
            SelectExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void ConfigSelect( SelectWrapperBuilder builder ) {
            ConfigUrl( builder );
            ConfigDataSource( builder );
            ConfigResetOption( builder );
            ConfigMultiple( builder );
            ConfigTemplate( builder );
            ConfigStandalone( builder );
        }

        /// <summary>
        /// 配置Url
        /// </summary>
        private void ConfigUrl( SelectWrapperBuilder builder ) {
            builder.AddAttribute( UiConst.Url, _config.GetValue( UiConst.Url ) );
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private void ConfigDataSource( SelectWrapperBuilder builder ) {
            AddItems();
            builder.AddAttribute( "[dataSource]", _config.GetValue( UiConst.DataSource ) );
        }

        /// <summary>
        /// 添加项集合
        /// </summary>
        private void AddItems() {
            if( _config.Items.Count == 0 )
                return;
            _config.SetAttribute( UiConst.DataSource, Util.Helpers.Json.ToJson( _config.Items, true ) );
        }

        /// <summary>
        /// 配置重置项
        /// </summary>
        private void ConfigResetOption( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[enableResetOption]", _config.GetBoolValue( MaterialConst.EnableResetOption ) );
            builder.AddAttribute( "resetOptionText", _config.GetValue( MaterialConst.ResetOptionText ) );
        }

        /// <summary>
        /// 配置多选
        /// </summary>
        private void ConfigMultiple( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[multiple]", _config.GetBoolValue( UiConst.Multiple ) );
        }

        /// <summary>
        /// 配置显示模板
        /// </summary>
        private void ConfigTemplate( SelectWrapperBuilder builder ) {
            builder.AddAttribute( UiConst.Template, _config.GetValue( UiConst.Template ) );
        }

        /// <summary>
        /// 配置独立
        /// </summary>
        private void ConfigStandalone( TagBuilder builder ) {
            builder.AddAttribute( "[standalone]", _config.GetBoolValue( UiConst.Standalone ) );
        }
    }
}
