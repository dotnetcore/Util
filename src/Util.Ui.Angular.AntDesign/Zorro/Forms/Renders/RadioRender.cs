﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Forms.Builders;
using Util.Ui.Zorro.Forms.Helpers;
using Util.Ui.Zorro.Grid.Helpers;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 单选框渲染器
    /// </summary>
    public class RadioRender : AngularRenderBase {
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
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new RadioWrapperBuilder();
            Config( builder );
            if( EnableLabel() )
                return GetFormItemBuilder( builder );
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
            ConfigGrid( builder );
            ConfigEvents( builder );
            ConfigUrl( builder );
            ConfigDataSource( builder );
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
            builder.AddAttribute( "[vertical]", _config.GetBoolValue( UiConst.Vertical ) );
            builder.AddAttribute( "label", _config.GetValue( UiConst.Label ) );
            builder.AddAttribute( "[label]", _config.GetValue( AngularConst.BindLabel ) );
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
            builder.NgModel( _config );
        }

        /// <summary>
        /// 配置必填项
        /// </summary>
        private void ConfigRequired( TagBuilder builder ) {
            builder.AddAttribute( "[required]", _config.GetBoolValue( UiConst.Required ) );
        }

        /// <summary>
        /// 配置栅格
        /// </summary>
        private void ConfigGrid( TagBuilder builder ) {
            var gridConfig = new GridConfig( builder, _config );
            gridConfig.Config();
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
            builder.AddAttribute( "[url]", _config.GetValue( AngularConst.BindUrl ) );
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private void ConfigDataSource( TagBuilder builder ) {
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
        /// 是否启用标签
        /// </summary>
        protected virtual bool EnableLabel() {
            return FormHelper.EnableLabel( _config );
        }

        /// <summary>
        /// 获取表单项生成器
        /// </summary>
        protected virtual TagBuilder GetFormItemBuilder( TagBuilder controlBuilder ) {
            return FormHelper.CreateFormItemBuilder( _config, controlBuilder );
        }
    }
}