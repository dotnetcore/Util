using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Avatars.Builders {
    /// <summary>
    /// 头像组标签生成器
    /// </summary>
    public class AvatarGroupBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化头像组标签生成器
        /// </summary>
        public AvatarGroupBuilder( Config config ) : base( config,"nz-avatar-group" ) {
        }
    }
}