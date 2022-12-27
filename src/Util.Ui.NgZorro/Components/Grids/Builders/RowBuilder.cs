using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgZorro.Components.Grids.Builders {
    /// <summary>
    /// 栅格行标签生成器
    /// </summary>
    public class RowBuilder : RowBuilderBase<RowBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化栅格行标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public RowBuilder( Config config ) : base( config,"div" ) {
            base.Attribute( "nz-row" );
            _config = config;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ConfigRow();
        }
    }
}