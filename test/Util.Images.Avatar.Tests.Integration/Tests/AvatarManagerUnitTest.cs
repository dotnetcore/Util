using System.Threading.Tasks;
using Moq;
using SixLabors.Fonts;
using Xunit;

namespace Util.Images.Tests {
    /// <summary>
    /// 测试头像服务 - 单元测试
    /// </summary>
    public class AvatarManagerUnitTest {

        #region 测试初始化

        /// <summary>
        /// 图片服务
        /// </summary>
        private readonly Mock<IImageManager> _mockImageManager;
        /// <summary>
        /// 图片操作包装器
        /// </summary>
        private readonly Mock<IImageWrapper> _mockImageWrapper;
        /// <summary>
        /// 头像服务
        /// </summary>
        private readonly AvatarManager _avatarManager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AvatarManagerUnitTest() {
            _mockImageManager = new Mock<IImageManager>();
            _mockImageWrapper = new Mock<IImageWrapper>();
            InitMockImageManager();
            InitMockImageWrapper();
            _avatarManager = new AvatarManager( _mockImageManager.Object );
        }

        /// <summary>
        /// 初始化图片模拟服务
        /// </summary>
        private void InitMockImageManager() {
            _mockImageManager.Setup( t => t.CreateImage( It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>() ) )
                .Returns( _mockImageWrapper.Object );
        }

        /// <summary>
        /// 初始化图片模拟包装器
        /// </summary>
        private void InitMockImageWrapper() {
            _mockImageWrapper.Setup( t => t.Font( It.IsAny<float>(), It.IsAny<FontStyle>(), It.IsAny<string>() ) )
                .Returns( _mockImageWrapper.Object );
            _mockImageWrapper.Setup( t => t.TextCenter( It.IsAny<string>(), It.IsAny<string>() ) )
                .Returns( _mockImageWrapper.Object );
        }

        #endregion

        #region Size

        /// <summary>
        /// 测试设置头像大小 - 默认值
        /// </summary>
        [Fact]
        public async Task TestSize_Default() {
            await _avatarManager.Text( "a" ).SaveAsync( "path" );
            _mockImageManager.Verify( t => t.CreateImage( 64, 64, It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置头像大小 - 最低有效值
        /// </summary>
        [Fact]
        public async Task TestSize_1() {
            await _avatarManager.Size( 16 ).Text( "a" ).SaveAsync( "path" );
            _mockImageManager.Verify( t => t.CreateImage( 16, 16, It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置头像大小 - 最高有效值
        /// </summary>
        [Fact]
        public async Task TestSize_2() {
            await _avatarManager.Size( 512 ).Text( "a" ).SaveAsync( "path" );
            _mockImageManager.Verify( t => t.CreateImage( 512, 512, It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置头像大小 - 低于最低有效值
        /// </summary>
        [Fact]
        public async Task TestSize_3() {
            await _avatarManager.Size( 1 ).Text( "a" ).SaveAsync( "path" );
            _mockImageManager.Verify( t => t.CreateImage( 16, 16, It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置头像大小 - 高于最高有效值
        /// </summary>
        [Fact]
        public async Task TestSize_4() {
            await _avatarManager.Size( 600 ).Text( "a" ).SaveAsync( "path" );
            _mockImageManager.Verify( t => t.CreateImage( 512, 512, It.IsAny<string>() ) );
        }

        #endregion

        #region Text

        /// <summary>
        /// 测试设置文本 - 设置一个空值
        /// </summary>
        [Fact]
        public async Task TestText_Null() {
            await _avatarManager.Text( null ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.TextCenter( It.IsAny<string>(), It.IsAny<string>() ),Times.Never );
        }

        /// <summary>
        /// 测试设置文本 - 设置一个字符
        /// </summary>
        [Fact]
        public async Task TestText_1() {
            await _avatarManager.Text( "a" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.TextCenter( "A",It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置文本 - 设置2个字符,默认长度为1
        /// </summary>
        [Fact]
        public async Task TestText_2() {
            await _avatarManager.Text( "ab" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.TextCenter( "A", It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置文本 - 设置2个字符,长度限制为2
        /// </summary>
        [Fact]
        public async Task TestText_3() {
            await _avatarManager.Text( "ab",2 ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.TextCenter( "AB", It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置文本 - 设置3个字符,长度限制为2
        /// </summary>
        [Fact]
        public async Task TestText_4() {
            await _avatarManager.Text( "abc", 2 ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.TextCenter( "AB", It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置文本 - 设置2个字符,长度限制为3
        /// </summary>
        [Fact]
        public async Task TestText_5() {
            await _avatarManager.Text( "ab", 3 ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.TextCenter( "AB", It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置文本 - 带加号
        /// </summary>
        [Fact]
        public async Task TestText_6() {
            await _avatarManager.Text( "ab+cd" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.TextCenter( "AC", It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置文本 - 加号有空格
        /// </summary>
        [Fact]
        public async Task TestText_7() {
            await _avatarManager.Text( "ab +   cd" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.TextCenter( "AC", It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置文本 - 2个加号,操作数有空值
        /// </summary>
        [Fact]
        public async Task TestText_8() {
            await _avatarManager.Text( " +   ab + cd " ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.TextCenter( "AC", It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置文本 - 不转大写
        /// </summary>
        [Fact]
        public async Task TestText_9() {
            await _avatarManager.Uppercase( false ).Text( "Ab+cd" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.TextCenter( "Ac", It.IsAny<string>() ) );
        }

        #endregion

        #region FontSize

        /// <summary>
        /// 测试设置字体大小 - 默认值
        /// </summary>
        [Fact]
        public async Task TestFontSize_Default() {
            await _avatarManager.Size( 128 ).Text( "a" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.Font( 64, It.IsAny<FontStyle>(), It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置字体大小 - 最低有效像素值
        /// </summary>
        [Fact]
        public async Task TestFontSize_1() {
            await _avatarManager.Size( 16 ).FontSize( 16 ).Text( "a" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.Font( 16,It.IsAny<FontStyle>(), It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置字体大小 - 最高有效像素值
        /// </summary>
        [Fact]
        public async Task TestFontSize_2() {
            await _avatarManager.Size( 512 ).FontSize( 512 ).Text( "a" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.Font( 512, It.IsAny<FontStyle>(), It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置字体大小 - 低于最低有效像素值
        /// </summary>
        [Fact]
        public async Task TestFontSize_3() {
            await _avatarManager.Size( 32 ).FontSize( 10 ).Text( "a" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.Font( 16, It.IsAny<FontStyle>(), It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置字体大小 - 字体像素高于头像像素
        /// </summary>
        [Fact]
        public async Task TestFontSize_4() {
            await _avatarManager.Size( 32 ).FontSize( 64 ).Text( "a" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.Font( 16, It.IsAny<FontStyle>(), It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置字体大小 - 高于最高有效像素值
        /// </summary>
        [Fact]
        public async Task TestFontSize_5() {
            await _avatarManager.Size( 128 ).FontSize( 600 ).Text( "a" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.Font( 64, It.IsAny<FontStyle>(), It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置字体大小 - 最小百分比
        /// </summary>
        [Fact]
        public async Task TestFontSize_6() {
            await _avatarManager.Size( 128 ).FontSize( 0.1 ).Text( "a" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.Font( 12.8f, It.IsAny<FontStyle>(), It.IsAny<string>() ) );
        }

        /// <summary>
        /// 测试设置字体大小 - 最大百分比
        /// </summary>
        [Fact]
        public async Task TestFontSize_7() {
            await _avatarManager.Size( 128 ).FontSize( 1 ).Text( "a" ).SaveAsync( "path" );
            _mockImageWrapper.Verify( t => t.Font( 128, It.IsAny<FontStyle>(), It.IsAny<string>() ) );
        }

        #endregion
    }
}
