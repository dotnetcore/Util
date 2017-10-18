using System;
using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Components;
using Util.Ui.Configs;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms {
    /// <summary>
    /// 表单
    /// </summary>
    public class Form : ContainerBase<IDisposable>, IForm {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">Html编码器</param>
        public Form( TextWriter writer, HtmlEncoder encoder ) : base( writer, encoder ) {
            _config = new Config();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return _config;
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IContainerRender GetRender() {
            return new FormRender( _config );
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected override IDisposable GetWrapper() {
            return new ContainerWrapper( this );
        }
    }
}
