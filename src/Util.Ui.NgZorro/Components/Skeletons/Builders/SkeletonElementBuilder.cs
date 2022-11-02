using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Skeletons.Builders {
    /// <summary>
    /// 骨架屏元素标签生成器
    /// </summary>
    public class SkeletonElementBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化骨架屏元素标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public SkeletonElementBuilder( Config config ) : base( config,"nz-skeleton-element" ) {
            _config = config;
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        public SkeletonElementBuilder Type() {
            AttributeIfNotEmpty( "nzType", _config.GetValue<SkeletonElementType?>( UiConst.Type )?.Description() );
            AttributeIfNotEmpty( "[nzType]", _config.GetValue( AngularConst.BindType ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示动画效果
        /// </summary>
        public SkeletonElementBuilder Active() {
            AttributeIfNotEmpty( "[nzActive]", _config.GetBoolValue( UiConst.Active ) );
            AttributeIfNotEmpty( "[nzActive]", _config.GetValue( AngularConst.BindActive ) );
            return this;
        }

        /// <summary>
        /// 配置大小
        /// </summary>
        public SkeletonElementBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<SkeletonElementSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置形状
        /// </summary>
        public SkeletonElementBuilder Shape() {
            AttributeIfNotEmpty( "nzShape", _config.GetValue<SkeletonElementShape?>( UiConst.Shape )?.Description() );
            AttributeIfNotEmpty( "[nzShape]", _config.GetValue( AngularConst.BindShape ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Type().Active().Size().Shape();
        }
    }
}