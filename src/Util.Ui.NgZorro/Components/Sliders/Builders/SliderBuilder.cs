using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Sliders.Builders {
    /// <summary>
    /// 滑动输入条标签生成器
    /// </summary>
    public class SliderBuilder : FormControlBuilderBase<SliderBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化滑动输入条标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public SliderBuilder( Config config ) : base( config, "nz-slider" ) {
            _config = config;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public SliderBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置是否只能拖拽到刻度
        /// </summary>
        public SliderBuilder Dots() {
            AttributeIfNotEmpty( "[nzDots]", _config.GetBoolValue( UiConst.Dots ) );
            AttributeIfNotEmpty( "[nzDots]", _config.GetValue( AngularConst.BindDots ) );
            return this;
        }

        /// <summary>
        /// 配置是否包含
        /// </summary>
        public SliderBuilder Included() {
            AttributeIfNotEmpty( "[nzIncluded]", _config.GetBoolValue( UiConst.Included ) );
            AttributeIfNotEmpty( "[nzIncluded]", _config.GetValue( AngularConst.BindIncluded ) );
            return this;
        }

        /// <summary>
        /// 配置刻度标记
        /// </summary>
        public SliderBuilder Marks() {
            AttributeIfNotEmpty( "[nzMarks]", _config.GetValue( UiConst.Marks ) );
            return this;
        }

        /// <summary>
        /// 配置最大值
        /// </summary>
        public SliderBuilder Max() {
            AttributeIfNotEmpty( "nzMax", _config.GetValue( UiConst.Max ) );
            AttributeIfNotEmpty( "[nzMax]", _config.GetValue( AngularConst.BindMax ) );
            return this;
        }

        /// <summary>
        /// 配置最小值
        /// </summary>
        public SliderBuilder Min() {
            AttributeIfNotEmpty( "nzMin", _config.GetValue( UiConst.Min ) );
            AttributeIfNotEmpty( "[nzMin]", _config.GetValue( AngularConst.BindMin ) );
            return this;
        }

        /// <summary>
        /// 配置双滑块模式
        /// </summary>
        public SliderBuilder Range() {
            AttributeIfNotEmpty( "[nzRange]", _config.GetBoolValue( UiConst.Range ) );
            AttributeIfNotEmpty( "[nzRange]", _config.GetValue( AngularConst.BindRange ) );
            return this;
        }

        /// <summary>
        /// 配置步长
        /// </summary>
        public SliderBuilder Step() {
            AttributeIfNotEmpty( "nzStep", _config.GetValue( UiConst.Step ) );
            AttributeIfNotEmpty( "[nzStep]", _config.GetValue( AngularConst.BindStep ) );
            return this;
        }

        /// <summary>
        /// 配置提示格式化函数
        /// </summary>
        public SliderBuilder TipFormatter() {
            AttributeIfNotEmpty( "[nzTipFormatter]", _config.GetValue( UiConst.TipFormatter ) );
            return this;
        }

        /// <summary>
        /// 配置垂直方向
        /// </summary>
        public SliderBuilder Vertical() {
            AttributeIfNotEmpty( "[nzVertical]", _config.GetBoolValue( UiConst.Vertical ) );
            AttributeIfNotEmpty( "[nzVertical]", _config.GetValue( AngularConst.BindVertical ) );
            return this;
        }

        /// <summary>
        /// 配置反向
        /// </summary>
        public SliderBuilder Reverse() {
            AttributeIfNotEmpty( "[nzReverse]", _config.GetBoolValue( UiConst.Reverse ) );
            AttributeIfNotEmpty( "[nzReverse]", _config.GetValue( AngularConst.BindReverse ) );
            return this;
        }

        /// <summary>
        /// 配置提示可见性
        /// </summary>
        public SliderBuilder TooltipVisible() {
            AttributeIfNotEmpty( "nzTooltipVisible", _config.GetValue<SliderTooltipVisible?>( UiConst.TooltipVisible )?.Description() );
            AttributeIfNotEmpty( "[nzTooltipVisible]", _config.GetValue( AngularConst.BindTooltipVisible ) );
            return this;
        }

        /// <summary>
        /// 配置提示位置
        /// </summary>
        public SliderBuilder TooltipPlacement() {
            AttributeIfNotEmpty( "nzTooltipPlacement", _config.GetValue<TooltipPlacement?>( UiConst.TooltipPlacement )?.Description() );
            AttributeIfNotEmpty( "[nzTooltipPlacement]", _config.GetValue( AngularConst.BindTooltipPlacement ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public SliderBuilder Events() {
            AttributeIfNotEmpty( "(nzOnAfterChange)", _config.GetValue( UiConst.OnAfterChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Disabled().Dots().Included().Marks()
                .Max().Min().Range().Step().TipFormatter().Vertical()
                .Reverse().TooltipVisible().TooltipPlacement()
                .Events();
        }
    }
}