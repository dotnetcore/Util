using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Steps.Builders {
    /// <summary>
    /// 步骤条标签生成器
    /// </summary>
    public class StepsBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化步骤条标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public StepsBuilder( Config config ) : base( config,"nz-steps" ) {
            _config = config;
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        public StepsBuilder Type() {
            AttributeIfNotEmpty( "nzType", _config.GetValue<StepsType?>( UiConst.Type )?.Description() );
            AttributeIfNotEmpty( "[nzType]", _config.GetValue( AngularConst.BindType ) );
            return this;
        }
        
        /// <summary>
        /// 配置当前步骤
        /// </summary>
        public StepsBuilder Current() {
            AttributeIfNotEmpty( "[nzCurrent]", _config.GetValue( UiConst.Current ) );
            AttributeIfNotEmpty( "[nzCurrent]", _config.GetValue( AngularConst.BindCurrent ) );
            return this;
        }

        /// <summary>
        /// 配置尺寸
        /// </summary>
        public StepsBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<StepsSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置起始序号
        /// </summary>
        public StepsBuilder StartIndex() {
            AttributeIfNotEmpty( "[nzStartIndex]", _config.GetValue( UiConst.StartIndex ) );
            AttributeIfNotEmpty( "[nzStartIndex]", _config.GetValue( AngularConst.BindStartIndex ) );
            return this;
        }

        /// <summary>
        /// 配置方向
        /// </summary>
        public StepsBuilder Direction() {
            AttributeIfNotEmpty( "nzDirection", _config.GetValue<StepsDirection?>( UiConst.Direction )?.Description() );
            AttributeIfNotEmpty( "[nzDirection]", _config.GetValue( AngularConst.BindDirection ) );
            return this;
        }

        /// <summary>
        /// 配置状态
        /// </summary>
        public StepsBuilder Status() {
            AttributeIfNotEmpty( "nzStatus", _config.GetValue<StepStatus?>( UiConst.Status )?.Description() );
            AttributeIfNotEmpty( "[nzStatus]", _config.GetValue( AngularConst.BindStatus ) );
            return this;
        }

        /// <summary>
        /// 配置点状
        /// </summary>
        public StepsBuilder ProgressDot() {
            AttributeIfNotEmpty( "[nzProgressDot]", _config.GetBoolValue( UiConst.ProgressDot ) );
            AttributeIfNotEmpty( "[nzProgressDot]", _config.GetValue( AngularConst.BindProgressDot ) );
            return this;
        }

        /// <summary>
        /// 配置标签位置
        /// </summary>
        public StepsBuilder LabelPlacement() {
            AttributeIfNotEmpty( "nzLabelPlacement", _config.GetValue<StepsLabelPlacement?>( UiConst.LabelPlacement )?.Description() );
            AttributeIfNotEmpty( "[nzLabelPlacement]", _config.GetValue( AngularConst.BindLabelPlacement ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public StepsBuilder Events() {
            AttributeIfNotEmpty( "(nzIndexChange)", _config.GetValue( UiConst.OnIndexChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Type().Current().Size().StartIndex().Direction().Status().ProgressDot().LabelPlacement().Events();
        }
    }
}