using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Tables.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Icons.Builders;
using Util.Ui.Prime.Enums;
using Util.Ui.Prime.TreeTables.Builders;

namespace Util.Ui.Prime.TreeTables.Renders {
    /// <summary>
    /// 树型表格列渲染器
    /// </summary>
    public class ColumnRender : AngularRenderBase {
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
            if ( AllowConfigContent() == false )
                return;
            var template = GetTemplate();
            if ( _config.Content == null || _config.Content.IsEmptyOrWhiteSpace )
                ConfigType( template );
            else
                template.AppendContent( _config.Content );
            builder.AppendContent( template );
        }

        /// <summary>
        /// 允许配置内容
        /// </summary>
        private bool AllowConfigContent() {
            if ( _config.Content != null && _config.Content.IsEmptyOrWhiteSpace == false )
                return true;
            var type = _config.GetValue<TableColumnType?>( UiConst.Type );
            if( type != null )
                return true;
            return false;
        }

        /// <summary>
        /// 获取模板
        /// </summary>
        private TemplateBuilder GetTemplate() {
            TemplateBuilder template = new TemplateBuilder();
            template.AddAttribute( "let-row", "rowData" );
            template.AddAttribute( "let-i", "index" );
            template.AddAttribute( "let-first", "first" );
            template.AddAttribute( "let-last", "last" );
            return template;
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        private void ConfigType( TemplateBuilder builder ) {
            var type = _config.GetValue<TableColumnType?>( UiConst.Type );
            if ( type == null )
                return;
            var column = _config.GetValue( UiConst.Column );
            switch( type ) {
                case TableColumnType.Bool:
                    AddBoolType( builder, column );
                    return;
                case TableColumnType.Date:
                    AddDateType( builder, column );
                    return;
            }
        }

        /// <summary>
        /// 添加布尔类型
        /// </summary>
        private void AddBoolType( TemplateBuilder builder, string column ) {
            var checkIconBuilder = new MaterialIconBuilder().SetContent( MaterialIcon.Check.Description() ).AddAttribute( "*ngIf", $"row.data.{column}" );
            builder.AppendContent( checkIconBuilder );
            var clearIconBuilder = new MaterialIconBuilder().SetContent( MaterialIcon.Clear.Description() ).AddAttribute( "*ngIf", $"!row.data.{column}" );
            builder.AppendContent( clearIconBuilder );
        }

        /// <summary>
        /// 添加日期类型
        /// </summary>
        private void AddDateType( TemplateBuilder builder, string column ) {
            var format = _config.GetValue( UiConst.DateFormat );
            if( string.IsNullOrWhiteSpace( format ) )
                format = "yyyy-MM-dd";
            builder.AppendContent( $"{{{{ row.data.{column} | date:\"{format}\" }}}}" );
        }
    }
}