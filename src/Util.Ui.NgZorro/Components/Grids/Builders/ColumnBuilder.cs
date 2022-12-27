using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgZorro.Components.Grids.Builders {
    /// <summary>
    /// 栅格列生成器
    /// </summary>
    public class ColumnBuilder : ColumnBuilderBase<ColumnBuilder> {
        /// <summary>
        /// 初始化栅格列生成器
        /// </summary>
        public ColumnBuilder( Config config ) : base( config, "div" ) {
            base.Attribute( "nz-col" );
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ConfigColumn();
        }
    }
}