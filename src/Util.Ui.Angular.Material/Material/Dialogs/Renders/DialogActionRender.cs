using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Dialogs.Builders;
using Util.Ui.Material.Enums;

namespace Util.Ui.Material.Dialogs.Renders {
    /// <summary>
    /// 弹出层操作渲染器
    /// </summary>
    public class DialogActionRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化弹出层操作渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DialogActionRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DialogActionBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            ConfigAlign( builder );
        }

        /// <summary>
        /// 配置对齐方式
        /// </summary>
        private void ConfigAlign( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Align, _config.GetValue<Align?>( UiConst.Align )?.Description() );
        }
    }
}