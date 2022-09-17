using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.VirtualScrolls.Builders {
    /// <summary>
    /// 虚拟滚动标签生成器
    /// </summary>
    public class VirtualScrollBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化虚拟滚动标签生成器
        /// </summary>
        public VirtualScrollBuilder( Config config ) : base( "ng-template" ) {
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
            LetData().LetIndex();
        }
    }
}