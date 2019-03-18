using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.Builders;

namespace Util.Ui.Material.Lists.Renders {
    /// <summary>
    /// 列表渲染器
    /// </summary>
    public class ListRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化列表渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ListRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ListBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            ConfigDense( builder );
        }

        /// <summary>
        /// 配置紧凑模式
        /// </summary>
        private void ConfigDense( TagBuilder builder ) {
            if( _config.GetValue<bool?>( UiConst.Dense ) == true )
                builder.AddAttribute( "dense" );
        }
    }
}