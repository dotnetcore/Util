using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Tables.Resolvers;
using Util.Ui.Prime.TreeTables.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Prime.TreeTables.Renders {
    /// <summary>
    /// 树型表格列渲染器
    /// </summary>
    public class ColumnRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化树型表格列
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new PrimeColumnBuilder();
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
            ColumnExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            builder.Style( _config );
            builder.Class( _config );
            ConfigId( builder );
            ConfigTitle( builder );
            ConfigColumn( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigTitle( TagBuilder builder ) {
            builder.AddAttribute( "header", _config.GetValue( UiConst.Title ) );
        }

        /// <summary>
        /// 配置列
        /// </summary>
        private void ConfigColumn( TagBuilder builder ) {
            builder.AddAttribute( "field", _config.GetValue( UiConst.Column ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Content == null || _config.Content.IsEmptyOrWhiteSpace )
                return;
            TemplateBuilder template = new TemplateBuilder();
            template.AddAttribute( "let-row", "rowData" );
            template.AppendContent( _config.Content );
            builder.AppendContent( template );
        }
    }
}