using Util.Ui.Configs;
using Util.Ui.Material.Forms.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 表单渲染器
    /// </summary>
    public class FormRender : ContainerRenderBase<FormBuilder, Config> {
        /// <summary>
        /// 初始化表单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormRender( Config config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override FormBuilder GetTagBuilder() {
            return new FormBuilder();
        }

        /// <summary>
        /// 渲染起始标签
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">组件配置</param>
        protected override void RenderStartTag( FormBuilder builder, Config config ) {
            AddAttributes( builder, config );
            builder.AddAttribute( "id", config.Id );
        }

        /// <summary>
        /// 添加属性列表
        /// </summary>
        private void AddAttributes( FormBuilder builder, Config config ) {
            foreach( var attribute in config.GetAttributes() )
                builder.Attribute( attribute.Key, attribute.Value );
        }
    }
}
