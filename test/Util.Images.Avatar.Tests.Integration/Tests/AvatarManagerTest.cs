using System.Threading.Tasks;
using Util.Helpers;
using Xunit;

namespace Util.Images.Tests {
    /// <summary>
    /// 测试头像操作
    /// </summary>
    public class AvatarManagerTest {
        /// <summary>
        /// 图片服务
        /// </summary>
        private readonly IAvatarManager _avatarManager;
        /// <summary>
        /// 输出路径
        /// </summary>
        private const string Path = @"D:\Util.Images.Avatar.Tests\{0}.gif";

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AvatarManagerTest( IAvatarManager avatarManager ) {
            _avatarManager = avatarManager;
        }

        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public async Task Test_1() {
            ImageManager.LoadFont( "a", Common.GetPhysicalPath( "~/Fonts/STZHONGS.TTF" ) );
            await _avatarManager
                .Size( 128 )
                .Uppercase( false )
                .Font( "a" )
                .FontSize( 64 )
                .Text( "Util+V" )
                .SaveAsync( string.Format( Path, "Test_1" ) );
        }
    }
}
