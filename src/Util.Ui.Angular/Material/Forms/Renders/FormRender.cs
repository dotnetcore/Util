using Util.Ui.Builders;
using Util.Ui.Configs;
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
            ConfigAttributes( builder );
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置属性
        /// </summary>
        private void ConfigAttributes( TagBuilder builder ) {
            ConfigId( builder );
            ConfigEvents( builder );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        private void ConfigId( TagBuilder builder ) {
            if( _config.Contains( UiConst.Id ) )
                builder.AddAttribute( $"#{_config.GetValue( UiConst.Id )}", "ngForm" );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(ngSubmit)", _config.GetValue( UiConst.OnSubmit ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private void ConfigContent( TagBuilder builder ) {
            builder.SetContent( _config.Content );
        }
    }
}
