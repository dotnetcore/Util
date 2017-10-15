using System;
using System.IO;
using System.Text.Encodings.Web;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Ui.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Components {
    /// <summary>
    /// 组件
    /// </summary>
    public abstract class ComponentBase<TConfig> : OptionBase<TConfig>, IComponent where TConfig : class, IConfig {
        /// <summary>
        /// 渲染器
        /// </summary>
        private IRender _render;
        /// <summary>
        /// 渲染器
        /// </summary>
        private IRender ComponentRender => _render ?? (_render = GetRender() );

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected abstract IRender GetRender();

        /// <summary>
        /// 写入文本流
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            RenderBefore( writer, encoder );
            Render( writer , encoder );
            RenderAfter( writer, encoder );
            WriteLog();
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
        private void Render( TextWriter writer, HtmlEncoder encoder ) {
            ComponentRender.Render( writer, encoder );
        }

        /// <summary>
        /// 渲染后操作
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        protected virtual void RenderAfter( TextWriter writer, HtmlEncoder encoder ) {
        }

        /// <summary>
        /// 写日志
        /// </summary>
        private void WriteLog() {
            var log = GetLog();
            if ( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( "组件渲染完成" )
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
            catch{
                return Log.Null;
            }
        }

        /// <summary>
        /// 输出组件Html
        /// </summary>
        public override string ToString() {
            return ComponentRender.ToString();
        }
    }
}
