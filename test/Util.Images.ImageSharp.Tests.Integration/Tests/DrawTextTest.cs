using System.Threading.Tasks;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Images.Tests {
    /// <summary>
    /// 测试图片操作 - 写文本
    /// </summary>
    public class DrawTextTest {
        /// <summary>
        /// 测试输出
        /// </summary>
        private readonly ITestOutputHelper _testOutputHelper;
        /// <summary>
        /// 图片服务
        /// </summary>
        private readonly IImageManager _imageManager;
        /// <summary>
        /// 输出路径
        /// </summary>
        private const string Path = @"D:\Util.Images.ImageSharp.Tests\{0}.gif";

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DrawTextTest( ITestOutputHelper testOutputHelper, IImageManager imageManager ) {
            _testOutputHelper = testOutputHelper;
            _imageManager = imageManager;
        }

        /// <summary>
        /// 测试 - 内置字体,指定坐标
        /// </summary>
        [Fact]
        public async Task Test_1() {
            await _imageManager.CreateImage( 128, 128, "5d005d" )
                .DefaultFontName( "Microsoft YaHei" )
                .Font( 48 )
                .Text( "U", "fff", 50, 38 )
                .SaveAsync( string.Format( Path, "Test_1" ) );
        }

        /// <summary>
        /// 测试 - 加载字体,居中显示
        /// </summary>
        [Fact]
        public async Task Test_2() {
            ImageManager.LoadFont( "a", Common.GetPhysicalPath( "~/Fonts/STZHONGS.TTF" ) );
            await _imageManager.CreateImage( 128, 128, "5d005d" )
                .Font( 48,"a" )
                .TextCenter( "U", "fff" )
                .SaveAsync( string.Format( Path, "Test_2" ) );
        }

        /// <summary>
        /// 测试获取流
        /// </summary>
        [Fact]
        public async Task TestToStreamAsync() {
            var result = await _imageManager.CreateImage( 128, 128, "5d005d" )
                .ImageType( ImageType.Gif )
                .Font( 48 )
                .TextCenter( "U", "fff" )
                .ToStreamAsync();
            await Util.Helpers.File.WriteAsync( string.Format( Path, "TestToStreamAsync" ),result );
        }

        /// <summary>
        /// 测试获取base64
        /// </summary>
        [Fact]
        public void TestToBase64() {
            var result = _imageManager.CreateImage( 128, 128, "5d005d" )
                .ImageType( ImageType.Gif )
                .Font( 48 )
                .TextCenter( "U", "fff" )
                .ToBase64();
            _testOutputHelper.WriteLine( result );
        }

        /// <summary>
        /// 测试受支持的字体列表
        /// </summary>
        [Fact]
        public void TestGetSupportedFonts() {
            ImageManager.LoadFont( "a", Common.GetPhysicalPath( "~/Fonts/STZHONGS.TTF" ) );
            var result = ImageManager.GetSupportedFonts();
            _testOutputHelper.WriteLine( result.Join() );
        }
    }
}
