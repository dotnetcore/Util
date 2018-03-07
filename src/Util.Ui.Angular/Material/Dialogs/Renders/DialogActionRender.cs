using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Dialogs.Builders;
using Util.Ui.Material.Enums;
using Util.Ui.Renders;

namespace Util.Ui.Material.Dialogs.Renders {
    /// <summary>
    /// 弹出层操作渲染器
    /// </summary>
    public class DialogActionRender : RenderBase {
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
            ConfigAlign( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置对齐方式
        /// </summary>
        private void ConfigAlign( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Align, _config.GetValue<Align?>( UiConst.Align )?.Description() );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private void ConfigContent( TagBuilder builder ) {
            if( _config.Content == null )
                return;
            builder.SetContent( _config.Content );
        }
    }
}