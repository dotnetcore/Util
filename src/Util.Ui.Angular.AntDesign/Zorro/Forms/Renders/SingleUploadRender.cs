using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms.Builders;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 单文件上传渲染器
    /// </summary>
    public class SingleUploadRender : UploadRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化单文件上传渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SingleUploadRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 创建上传包装器生成器
        /// </summary>
        protected override TagBuilder CreateBuilder() {
            return new SingleUploadWrapperBuilder();
        }
    }
}
