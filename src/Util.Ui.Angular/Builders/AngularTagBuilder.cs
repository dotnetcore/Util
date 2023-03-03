using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.Extensions;

namespace Util.Ui.Angular.Builders {
    /// <summary>
    /// Angular标签生成器
    /// </summary>
    public class AngularTagBuilder : Util.Ui.Builders.TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化Angular标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tagName">标签名称，范例：div</param>
        /// <param name="renderMode">渲染模式</param>
        public AngularTagBuilder( Config config, string tagName, TagRenderMode renderMode = TagRenderMode.Normal ) : base( tagName, renderMode ) {
            _config = config ?? throw new ArgumentNullException( nameof( config ) );
        }

        /// <inheritdoc />
        public override void Config() {
            ConfigBase( _config );
            ConfigContent( _config );
        }

        /// <summary>
        /// 基础配置
        /// </summary>
        /// <param name="config">配置</param>
        public override void ConfigBase( Config config ) {
            base.ConfigBase( config );
            this.Angular( config );
            ConfigId( config );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected virtual void ConfigId( Config config ) {
            this.RawId( config );
            this.Id( config );
        }

        /// <summary>
        /// 配置内容元素
        /// </summary>
        protected virtual void ConfigContent( Config config ) {
            config.Content.AppendTo( this );
        }
    }
}