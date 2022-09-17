using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Avatars.Builders {
    /// <summary>
    /// 头像组标签生成器
    /// </summary>
    public class AvatarGroupBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化头像组标签生成器
        /// </summary>
        public AvatarGroupBuilder( Config config ) : base( "nz-avatar-group" ) {
            _config = config;
        }
    }
}