using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Helpers;
using Util.Ui.Zorro.Forms.Base;
using Util.Ui.Zorro.Forms.Builders;
using Util.Ui.Zorro.Forms.Helpers;

namespace Util.Ui.Zorro.Forms.Renders {
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
            Config( builder );
            ConfigSelect( builder );
            return GetFormItemBuilder( builder );
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        private void ResolveExpression() {
            if( _config.Contains( UiConst.For ) == false )
                return;
            var expression = _config.GetValue<ModelExpression>( UiConst.For );
            SelectExpressionResolver.Init( expression, _config, IsTableEdit() );
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void ConfigSelect( SelectWrapperBuilder builder ) {
            ConfigWidth( builder );
            ConfigUrl( builder );
            ConfigDataSource( builder );
            ConfigDefaultOption( builder );
            ConfigMode( builder );
            ConfigShowClear( builder );
            ConfigSearch( builder );
            ConfigShowArrow( builder );
            ConfigTemplate( builder );
            ConfigStandalone( builder );
            ConfigEvents( builder );
        }

        /// <summary>
        /// 配置宽度
        /// </summary>
        private void ConfigWidth( SelectWrapperBuilder builder ) {
            var width = _config.GetValue( UiConst.Width );
            builder.AddAttribute( UiConst.Width, CommonHelper.GetPixelValue( width ) );
        }

        /// <summary>
        /// 配置Url
        /// </summary>
        private void ConfigUrl( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[autoLoad]", _config.GetBoolValue( UiConst.AutoLoad ) );
            builder.AddAttribute( UiConst.Url, _config.GetValue( UiConst.Url ) );
            builder.AddAttribute( "[url]", _config.GetValue( AngularConst.BindUrl ) );
            builder.AddAttribute( "[queryParam]", _config.GetValue( UiConst.QueryParam ) );
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private void ConfigDataSource( SelectWrapperBuilder builder ) {
            AddItems();
            builder.AddAttribute( "[dataSource]", _config.GetValue( UiConst.Data ) );
        }

        /// <summary>
        /// 添加项集合
        /// </summary>
        private void AddItems() {
            if( _config.Items.Count == 0 )
                return;
            _config.SetAttribute( UiConst.Data, Util.Helpers.Json.ToJson( _config.Items, true ) );
        }

        /// <summary>
        /// 配置默认项
        /// </summary>
        private void ConfigDefaultOption( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "defaultOptionText", _config.GetValue( UiConst.DefaultOptionText ) );
        }

        /// <summary>
        /// 配置多选模式
        /// </summary>
        private void ConfigMode( SelectWrapperBuilder builder ) {
            var mode = _config.GetValue<SelectMode?>( UiConst.Mode );
            if( mode == SelectMode.Multiple )
                _config.SetAttribute( UiConst.Multiple,true );
            if( mode == SelectMode.Tags )
                _config.SetAttribute( UiConst.Tags, true );
            builder.AddAttribute( "[multiple]", _config.GetBoolValue( UiConst.Multiple ) );
            builder.AddAttribute( "[tags]", _config.GetBoolValue( UiConst.Tags ) );
            builder.AddAttribute( "[maxMultipleCount]", _config.GetValue( UiConst.MaxMultipleCount ) );
        }

        /// <summary>
        /// 配置显示清除按钮
        /// </summary>
        private void ConfigShowClear( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[allowClear]", _config.GetBoolValue( UiConst.ShowClear ) );
        }

        /// <summary>
        /// 配置搜索
        /// </summary>
        private void ConfigSearch( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "order", _config.GetValue( UiConst.Sort ) );
            builder.AddAttribute( "[showSearch]", _config.GetBoolValue( UiConst.ShowSearch ) );
            builder.AddAttribute( "[isServerSearch]", _config.GetBoolValue( UiConst.ServerSearch ) );
            builder.AddAttribute( "[isScrollLoad]", _config.GetBoolValue( UiConst.ScrollLoad ) );
        }

        /// <summary>
        /// 配置显示箭头
        /// </summary>
        private void ConfigShowArrow( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[showArrow]", _config.GetBoolValue( UiConst.ShowArrow ) );
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

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onSearch)", _config.GetValue( UiConst.OnSearch ) );
            builder.AddAttribute( "(onScrollToBottom)", _config.GetValue( UiConst.OnScrollToBottom ) );
        }
    }
}
