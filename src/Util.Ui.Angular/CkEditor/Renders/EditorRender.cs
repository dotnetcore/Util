using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.CkEditor.Builders;
using Util.Ui.CkEditor.Configs;
using Util.Ui.CkEditor.Resolvers;
using Util.Ui.Configs;

namespace Util.Ui.CkEditor.Renders {
    /// <summary>
    /// 富文本框编辑器渲染器
    /// </summary>
    public class EditorRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化富文本框编辑器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public EditorRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new CkEditorBuilder();
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
            CkEditorExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigName( builder );
            ConfigModel( builder );
            ConfigCkEditor( builder );
        }

        /// <summary>
        /// 配置名称
        /// </summary>
        private void ConfigName( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Name, _config.GetValue( UiConst.Name ) );
            builder.AddAttribute( "[name]", _config.GetValue( AngularConst.BindName ) );
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.AddAttribute( "[(ngModel)]", _config.GetValue( UiConst.Model ) );
        }

        /// <summary>
        /// 配置编辑器
        /// </summary>
        private void ConfigCkEditor( TagBuilder builder ) {
            var config = GetCkEditorConfig();
            var json = Util.Helpers.Json.ToJson( config, true );
            if ( json == "{}" )
                return;
            builder.AddAttribute( "[config]", json );
        }

        /// <summary>
        /// 获取CkEditor配置
        /// </summary>
        private CkEditorConfig GetCkEditorConfig() {
            var result = new CkEditorConfig {
                FileBrowserUploadUrl = _config.GetValueOrNull( UiConst.UploadUrl ),
                Height = _config.GetValueOrNull( UiConst.Height ),
                AllowedContent = _config.GetValue( UiConst.DisableFilter ).ToBoolOrNull()
            };
            return result;
        }
    }
}