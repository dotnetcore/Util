using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Skeletons.Builders {
    /// <summary>
    /// 骨架屏标签生成器
    /// </summary>
    public class SkeletonBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化骨架屏标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public SkeletonBuilder( Config config ) : base( config,"nz-skeleton" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否显示动画效果
        /// </summary>
        public SkeletonBuilder Active() {
            AttributeIfNotEmpty( "[nzActive]", _config.GetBoolValue( UiConst.Active ) );
            AttributeIfNotEmpty( "[nzActive]", _config.GetValue( AngularConst.BindActive ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示头像占位图
        /// </summary>
        public SkeletonBuilder Avatar() {
            AttributeIfNotEmpty( "[nzAvatar]", _config.GetValue( UiConst.Avatar ) );
            return this;
        }

        /// <summary>
        /// 配置是否加载状态
        /// </summary>
        public SkeletonBuilder Loading() {
            AttributeIfNotEmpty( "[nzLoading]", _config.GetValue( UiConst.Loading ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示段落占位图
        /// </summary>
        public SkeletonBuilder Paragraph() {
            AttributeIfNotEmpty( "[nzParagraph]", _config.GetValue( UiConst.Paragraph ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示标题占位图
        /// </summary>
        public SkeletonBuilder Title() {
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( UiConst.Title ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示圆角
        /// </summary>
        public SkeletonBuilder Round() {
            AttributeIfNotEmpty( "[nzRound]", _config.GetBoolValue( UiConst.Round ) );
            AttributeIfNotEmpty( "[nzRound]", _config.GetValue( AngularConst.BindRound ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Active().Avatar().Loading().Paragraph().Title().Round();
        }
    }
}