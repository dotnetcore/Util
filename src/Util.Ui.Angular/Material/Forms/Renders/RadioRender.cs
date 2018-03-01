using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Commons.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.Builders;
using Util.Ui.Material.Forms.Configs;
using Util.Ui.Material.Forms.Resolvers;
using Util.Ui.Material.Grids.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 单选框渲染器
    /// </summary>
    public class RadioRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly SelectConfig _config;

        /// <summary>
        /// 初始化单选框渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public RadioRender( SelectConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            RenderBeforeColumn( writer, encoder );
            RenderFormControl( writer, encoder );
            RenderAfterColumn( writer, encoder );
        }

        /// <summary>
        /// 渲染左侧占位列
        /// </summary>
        private void RenderBeforeColumn( TextWriter writer, HtmlEncoder encoder ) {
            if( _config.Contains( UiConst.BeforeColspan ) == false )
                return;
            var builder = new GridColumnBuilder();
            builder.AddColspan( _config, UiConst.BeforeColspan );
            builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染表单控件
        /// </summary>
        private void RenderFormControl( TextWriter writer, HtmlEncoder encoder ) {
            if( _config.Contains( UiConst.Colspan ) == false ) {
                Builder.WriteTo( writer, encoder );
                return;
            }
            var columnBuilder = new GridColumnBuilder();
            columnBuilder.AddColspan( _config, UiConst.Colspan );
            columnBuilder.SetContent( Builder );
            columnBuilder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染右侧占位列
        /// </summary>
        private void RenderAfterColumn( TextWriter writer, HtmlEncoder encoder ) {
            if( _config.Contains( UiConst.AfterColspan ) == false )
                return;
            var builder = new GridColumnBuilder();
            builder.AddColspan( _config, UiConst.AfterColspan );
            builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new RadioWrapperBuilder();
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
            SelectExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigName( builder );
            ConfigLabel( builder );
            ConfigDisabled( builder );
            ConfigModel( builder );
            ConfigRequired( builder );
            ConfigEvents( builder );
            ConfigUrl( builder );
            ConfigDataSource( builder );
        }

        /// <summary>
        /// 配置名称
        /// </summary>
        private void ConfigName( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Name, _config.GetValue( UiConst.Name ) );
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        private void ConfigLabel( TagBuilder builder ) {
            builder.AddAttribute( "[vertical]", _config.GetBoolValue( UiConst.Vertical ) );
            builder.AddAttribute( "[showLabel]", _config.GetBoolValue( MaterialConst.ShowLabel ) );
            builder.AddAttribute( "label", _config.GetValue( UiConst.Label ) );
            builder.AddAttribute( "labelPosition", _config.GetValue<XPosition?>( UiConst.Position )?.Description() );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.AddAttribute( "[(model)]", _config.GetValue( UiConst.Model ) );
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
            builder.AddAttribute( "(onChange)", _config.GetValue( UiConst.OnChange ) );
        }

        /// <summary>
        /// 配置Url
        /// </summary>
        private void ConfigUrl( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Url, _config.GetValue( UiConst.Url ) );
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private void ConfigDataSource( TagBuilder builder ) {
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
    }
}