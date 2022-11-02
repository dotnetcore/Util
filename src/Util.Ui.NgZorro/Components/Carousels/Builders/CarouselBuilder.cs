using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Carousels.Builders {
    /// <summary>
    /// 走马灯标签生成器
    /// </summary>
    public class CarouselBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化走马灯标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public CarouselBuilder( Config config ) : base( config,"nz-carousel" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否自动切换
        /// </summary>
        public CarouselBuilder AutoPlay() {
            AttributeIfNotEmpty( "[nzAutoPlay]", _config.GetBoolValue( UiConst.AutoPlay ) );
            AttributeIfNotEmpty( "[nzAutoPlay]", _config.GetValue( AngularConst.BindAutoPlay ) );
            return this;
        }

        /// <summary>
        /// 配置是否自动切换
        /// </summary>
        public CarouselBuilder AutoPlaySpeed() {
            AttributeIfNotEmpty( "nzAutoPlaySpeed", _config.GetValue( UiConst.AutoPlaySpeed ) );
            AttributeIfNotEmpty( "[nzAutoPlaySpeed]", _config.GetValue( AngularConst.BindAutoPlaySpeed ) );
            return this;
        }

        /// <summary>
        /// 配置指示点渲染模板
        /// </summary>
        public CarouselBuilder DotRender() {
            AttributeIfNotEmpty( "[nzDotRender]", _config.GetValue( UiConst.DotRender ) );
            return this;
        }

        /// <summary>
        /// 配置指示点位置
        /// </summary>
        public CarouselBuilder DotPosition() {
            AttributeIfNotEmpty( "nzDotPosition", _config.GetValue<CarouselDotPosition?>( UiConst.DotPosition )?.Description() );
            AttributeIfNotEmpty( "[nzDotPosition]", _config.GetValue( AngularConst.BindDotPosition ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示指示点
        /// </summary>
        public CarouselBuilder Dots() {
            AttributeIfNotEmpty( "[nzDots]", _config.GetBoolValue( UiConst.Dots ) );
            AttributeIfNotEmpty( "[nzDots]", _config.GetValue( AngularConst.BindDots ) );
            return this;
        }

        /// <summary>
        /// 配置动画效果
        /// </summary>
        public CarouselBuilder Effect() {
            AttributeIfNotEmpty( "nzEffect", _config.GetValue<CarouselEffect?>( UiConst.Effect )?.Description() );
            AttributeIfNotEmpty( "[nzEffect]", _config.GetValue( AngularConst.BindEffect ) );
            return this;
        }

        /// <summary>
        /// 配置是否支持手势划动切换
        /// </summary>
        public CarouselBuilder EnableSwipe() {
            AttributeIfNotEmpty( "[nzEnableSwipe]", _config.GetBoolValue( UiConst.EnableSwipe ) );
            AttributeIfNotEmpty( "[nzEnableSwipe]", _config.GetValue( AngularConst.BindEnableSwipe ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public CarouselBuilder Events() {
            AttributeIfNotEmpty( "(nzAfterChange)", _config.GetValue( UiConst.OnAfterChange ) );
            AttributeIfNotEmpty( "(nzBeforeChange)", _config.GetValue( UiConst.OnBeforeChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            AutoPlay().AutoPlaySpeed().DotRender().DotPosition()
                .Dots().Effect().EnableSwipe()
                .Events();
        }
    }
}