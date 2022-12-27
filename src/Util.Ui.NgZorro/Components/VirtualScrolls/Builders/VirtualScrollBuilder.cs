using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.VirtualScrolls.Builders {
    /// <summary>
    /// 虚拟滚动标签生成器
    /// </summary>
    public class VirtualScrollBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化虚拟滚动标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public VirtualScrollBuilder( Config config ) : base( config,"ng-template" ) {
            _config = config;
            base.Attribute( "nz-virtual-scroll" );
        }

        /// <summary>
        /// 配置数据引用
        /// </summary>
        public VirtualScrollBuilder LetData() {
            if( _config.Contains( UiConst.LetData ) )
                Attribute( "let-data" );
            return this;
        }

        /// <summary>
        /// 配置索引引用
        /// </summary>
        public VirtualScrollBuilder LetIndex() {
            if( _config.Contains( UiConst.LetIndex ) )
                Attribute( "let-index", "index" );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            LetData().LetIndex();
        }
    }
}