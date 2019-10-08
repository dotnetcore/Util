using System;
using System.IO;
using System.Text.Encodings.Web;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Components {
    /// <summary>
    /// 组件
    /// </summary>
    public abstract class ComponentBase : IComponent, IOptionConfig {
        /// <summary>
        /// 渲染器
        /// </summary>
        private IRender _render;
        /// <summary>
        /// 渲染器
        /// </summary>
        protected IRender Render => _render ?? ( _render = GetRender() );
        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected abstract IRender GetRender();

        /// <summary>
        /// 配置
        /// </summary>
        private IConfig _config;
        /// <summary>
        /// 配置
        /// </summary>
        protected IConfig OptionConfig => _config ?? ( _config = GetConfig() );
        /// <summary>
        /// 获取配置
        /// </summary>
        protected virtual IConfig GetConfig() {
            return new Config();
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <typeparam name="TConfig">配置类型</typeparam>
        /// <param name="configAction">配置方法</param>
        public void Config<TConfig>( Action<TConfig> configAction ) where TConfig : IConfig {
            if( configAction == null )
                throw new ArgumentNullException( nameof( configAction ) );
            IConfig config = OptionConfig;
            configAction( (TConfig)config );
        }

        /// <summary>
        /// 写入文本流
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            RenderBefore( writer, encoder );
            RenderContent( writer , encoder );
            RenderAfter( writer, encoder );
        }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        protected virtual void RenderBefore( TextWriter writer, HtmlEncoder encoder ) {
        }

        /// <summary>
        /// 渲染操作
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        private void RenderContent( TextWriter writer, HtmlEncoder encoder ) {
            Render.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染后操作
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        protected virtual void RenderAfter( TextWriter writer, HtmlEncoder encoder ) {
        }

        /// <summary>
        /// 输出组件Html
        /// </summary>
        public override string ToString() {
            return Render.ToString();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog( string caption ) {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( caption )
                .Content( ToString() )
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog() {
            try {
                return Log.GetLog( TraceLogName );
            }
            catch {
                return Log.Null;
            }
        }

        /// <summary>
        /// 跟踪日志名
        /// </summary>
        public const string TraceLogName = "UiTraceLog";
    }
}
