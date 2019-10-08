﻿using System;
using System.IO;
using Util.Ui.Components.Internal;

namespace Util.Ui.Components {
    /// <summary>
    /// 容器
    /// </summary>
    /// <typeparam name="TWrapper">容器包装器类型</typeparam>
    public abstract class ContainerBase<TWrapper> : ComponentBase, IContainer<TWrapper>, IRenderEnd
        where TWrapper : IDisposable {
        /// <summary>
        /// 初始化容器
        /// </summary>
        /// <param name="writer">流写入器</param>
        protected ContainerBase( TextWriter writer ) {
            Writer = writer;
        }

        /// <summary>
        /// 流写入器
        /// </summary>
        public TextWriter Writer { get; set; }

        /// <summary>
        /// 准备渲染容器
        /// </summary>
        public TWrapper Begin() {
            if( Writer == null )
                throw new ArgumentNullException( "TextWriter未设置" );
            Render.RenderStartTag( Writer );
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
            Render.RenderEndTag( Writer );
        }
    }
}
