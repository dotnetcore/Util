using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Forms.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 表单渲染器
    /// </summary>
    public class FormRender : ContainerRenderBase<FormBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override FormBuilder GetTagBuilder() {
            var builder = new FormBuilder();
            builder.AddOtherAttributes( _config );
            builder.Id( _config );
            return builder;
        }
    }
}
