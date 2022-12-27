using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Spaces.Builders {
    /// <summary>
    /// 间距标签生成器
    /// </summary>
    public class SpaceBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化间距标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public SpaceBuilder( Config config ) : base( config,"nz-space" ) {
            _config = config;
        }

        /// <summary>
        /// 配置间距大小
        /// </summary>
        public SpaceBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<SpaceSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置间距方向
        /// </summary>
        public SpaceBuilder Direction() {
            AttributeIfNotEmpty( "nzDirection", _config.GetValue<SpaceDirection?>( UiConst.Direction )?.Description() );
            AttributeIfNotEmpty( "[nzDirection]", _config.GetValue( AngularConst.BindDirection ) );
            return this;
        }

        /// <summary>
        /// 配置对齐方式
        /// </summary>
        public SpaceBuilder Align() {
            AttributeIfNotEmpty( "nzAlign", _config.GetValue<SpaceAlign?>( UiConst.Align )?.Description() );
            AttributeIfNotEmpty( "[nzAlign]", _config.GetValue( AngularConst.BindAlign ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Size().Direction().Align();
        }
    }
}