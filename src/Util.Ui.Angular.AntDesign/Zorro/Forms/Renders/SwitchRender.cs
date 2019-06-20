using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms.Builders;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 开关渲染器
    /// </summary>
    public class SwitchRender : CheckBoxRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化开关渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SwitchRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new SwitchBuilder();
            Config( builder );
            var formControlBuilder = new FormControlBuilder();
            if( formControlBuilder.HasGrid( _config ) == false )
                return builder;
            formControlBuilder.AddLayout( _config );
            formControlBuilder.AppendContent( builder );
            return formControlBuilder;
        }

        /// <summary>
        /// 配置变更事件
        /// </summary>
        protected override void ConfigOnChange( TagBuilder builder ) {
            builder.AddAttribute( "(ngModelChange)", _config.GetValue( UiConst.OnChange ) );
        }
    }
}
