using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Helpers;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Forms.Builders;
using Util.Ui.Zorro.Forms.Configs;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 复选框组渲染器
    /// </summary>
    public class CheckboxGroupRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly CheckboxGroupConfig _config;

        /// <summary>
        /// 初始化复选框组渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CheckboxGroupRender( CheckboxGroupConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new CheckboxGroupWrapperBuilder();
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
            ExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigName( builder );
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
            builder.AddAttribute( "[name]", _config.GetValue( AngularConst.BindName ) );
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
            builder.AddAttribute( "[(model)]", _config.GetValue( AngularConst.NgModel ) );
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
            AddDataSource();
            builder.AddAttribute( "[dataSource]", _config.GetValue( AngularConst.BindData ) );
        }

        /// <summary>
        /// 添加项集合
        /// </summary>
        private void AddDataSource() {
            var expression = _config.GetValue<ModelExpression>( UiConst.Data );
            if ( expression == null )
                return;
            AddItems( expression );
            if( _config.Items.Count == 0 )
                return;
            _config.SetAttribute( AngularConst.BindData, Util.Helpers.Json.ToJson( _config.Items, true ) );
        }

        /// <summary>
        /// 添加列表
        /// </summary>
        private void AddItems( ModelExpression expression ) {
            var memberInfo = expression.GetMemberInfo();
            if( Reflection.IsBool( memberInfo ) )
                _config.AddBool();
            else if( Reflection.IsEnum( memberInfo ) )
                _config.AddEnum( expression.Metadata.ModelType );
        }
    }
}