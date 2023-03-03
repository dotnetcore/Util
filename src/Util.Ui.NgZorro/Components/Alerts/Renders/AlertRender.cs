using Microsoft.AspNetCore.Html;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Alerts.Builders;
using Util.Ui.NgZorro.Components.Alerts.Configs;
using Util.Ui.NgZorro.Components.Templates.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Alerts.Renders {
    /// <summary>
    /// 警告提示渲染器
    /// </summary>
    public class AlertRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 警告提示共享配置
        /// </summary>
        private readonly AlertShareConfig _shareConfig;

        /// <summary>
        /// 初始化警告提示渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public AlertRender( Config config ) {
            _config = config;
            _shareConfig = GetShareConfig();
        }

        /// <summary>
        /// 获取共享配置
        /// </summary>
        private AlertShareConfig GetShareConfig() {
            return _config.GetValueFromItems<AlertShareConfig>();
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AlertBuilder( _config );
            builder.Config();
            SetContent( builder );
            return builder;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        private void SetContent( AlertBuilder alertBuilder ) {
            if ( IsAutoCreateTemplate() == false ) {
                _config.Content.AppendTo( alertBuilder );
                return;
            }
            alertBuilder.BindMessage( _shareConfig.TemplateId );
            var template = CreateTemplate();
            alertBuilder.SetContent( template );
            _config.Content.AppendTo( template );
        }

        /// <summary>
        /// 是否自动创建ng-template
        /// </summary>
        private bool IsAutoCreateTemplate() {
            if ( _shareConfig.IsAutoCreateTemplate == false )
                return false;
            if ( _config.Content.IsEmpty() )
                return false;
            if ( _config.Contains( AngularConst.BindMessage ) )
                return false;
            return true;
        }

        /// <summary>
        /// 创建模板
        /// </summary>
        private TagBuilder CreateTemplate() {
            if ( IsAutoCreateTemplate() == false )
                return new EmptyContainerTagBuilder();
            var result = new TemplateBuilder( _config );
            result.Id( _shareConfig.TemplateId );
            return result;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new AlertRender( _config.Copy() );
        }
    }
}