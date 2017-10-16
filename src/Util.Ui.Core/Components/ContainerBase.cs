using System;
using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Components {
    /// <summary>
    /// 容器
    /// </summary>
    /// <typeparam name="TConfig">配置类型</typeparam>
    /// <typeparam name="TWrapper">容器包装器类型</typeparam>
    public abstract class ContainerBase<TConfig, TWrapper> : OptionBase<TConfig>, IContainer<TWrapper>, IRenderEnd
        where TConfig : class, IConfig
        where TWrapper : IDisposable {
        /// <summary>
        /// 流写入器
        /// </summary>
        private readonly TextWriter _writer;
        /// <summary>
        /// Html编码器
        /// </summary>
        private readonly HtmlEncoder _encoder;
        /// <summary>
        /// 渲染器
        /// </summary>
        private IContainerRender _render;

        /// <summary>
        /// 初始化容器
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">Html编码器</param>
        protected ContainerBase( TextWriter writer, HtmlEncoder encoder ) {
            writer.CheckNull( nameof( writer ) );
            _writer = writer;
            _encoder = encoder;
        }

        /// <summary>
        /// 渲染器
        /// </summary>
        private IContainerRender Render => _render ?? ( _render = GetRender() );

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected abstract IContainerRender GetRender();

        /// <summary>
        /// 准备渲染容器
        /// </summary>
        public TWrapper Begin() {
            Render.RenderStartTag( _writer, _encoder );
            WriteLog( "渲染容器" );
            return GetWrapper();
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected abstract TWrapper GetWrapper();

        /// <summary>
        /// 容器渲染结束
        /// </summary>
        public void End() {
            Render.RenderEndTag( _writer, _encoder );
        }

        /// <summary>
        /// 输出Html
        /// </summary>
        public override string ToString() {
            return Render.ToString();
        }
    }
}
