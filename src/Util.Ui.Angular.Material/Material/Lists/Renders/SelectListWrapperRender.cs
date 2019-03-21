using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Grids.Builders;
using Util.Ui.Material.Lists.Builders;

namespace Util.Ui.Material.Lists.Renders {
    /// <summary>
    /// 选择列表包装器渲染器
    /// </summary>
    public class SelectListWrapperRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly SelectConfig _config;

        /// <summary>
        /// 初始化选择列表包装器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SelectListWrapperRender( SelectConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            RenderBeforeColumn( writer, encoder );
            RenderControl( writer, encoder );
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
        /// 渲染控件
        /// </summary>
        private void RenderControl( TextWriter writer, HtmlEncoder encoder ) {
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
            var builder = new SelectListWrapperBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigDataSource( builder );
            ConfigName( builder );
            ConfigDisabled( builder );
            ConfigModel( builder );
            ConfigEvents( builder );
            ConfigLabel( builder );
            ConfigCheckboxPosition( builder );
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private void ConfigDataSource( TagBuilder builder ) {
            AddItems();
            builder.AddAttribute( "[dataSource]", _config.GetValue( UiConst.DataSource ) );
            builder.AddAttribute( "url", _config.GetValue( UiConst.Url ) );
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
        /// 配置名称
        /// </summary>
        private void ConfigName( TagBuilder builder ) {
            builder.AddAttribute( "name", _config.GetValue( UiConst.Name ) );
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
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onChange)", _config.GetValue( UiConst.OnChange ) );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigLabel( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Label, _config.GetValue( UiConst.Label ) );
        }

        /// <summary>
        /// 配置复选框位置
        /// </summary>
        private void ConfigCheckboxPosition( TagBuilder builder ) {
            builder.AddAttribute( "checkboxPosition", _config.GetValue<XPosition?>( MaterialConst.CheckboxPosition )?.Description() );
        }
    }
}