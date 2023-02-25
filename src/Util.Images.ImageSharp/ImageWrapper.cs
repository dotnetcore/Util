using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SixLabors.Fonts;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using Util.Images.Commands;
using System.Numerics;
using System.Threading;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;

namespace Util.Images {
    /// <summary>
    /// 图片操作包装器
    /// </summary>
    public class ImageWrapper : IImageWrapper {

        #region 属性

        /// <summary>
        /// 调用命令
        /// </summary>
        private readonly List<ICommand> _commands = new();
        /// <summary>
        /// 图片类型
        /// </summary>
        private ImageType _imageType;
        /// <summary>
        /// 宽度
        /// </summary>
        private readonly int _width;
        /// <summary>
        /// 高度
        /// </summary>
        private readonly int _height;
        /// <summary>
        /// 背景色
        /// </summary>
        private readonly string _backgroundColor;
        /// <summary>
        /// 图片加载路径
        /// </summary>
        private readonly string _loadPath;
        /// <summary>
        /// 默认字符名称
        /// </summary>
        private static string _defaultFontName;
        /// <summary>
        /// 字体
        /// </summary>
        private Font _font;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化图片操作
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="backgroundColor">背景色</param>
        public ImageWrapper( int width, int height, string backgroundColor ) {
            _imageType = Images.ImageType.Png;
            _width = width;
            _height = height;
            _backgroundColor = backgroundColor;
        }

        /// <summary>
        /// 初始化图片操作
        /// </summary>
        /// <param name="path">图片路径</param>
        public ImageWrapper( string path ) {
            _imageType = Images.ImageType.Png;
            _loadPath = path;
        }

        #endregion

        #region ImageType

        /// <summary>
        /// 设置图片类型
        /// </summary>
        /// <param name="type">图片类型</param>
        public IImageWrapper ImageType( ImageType type ) {
            _imageType = type;
            return this;
        }

        #endregion

        #region DefaultFontName

        /// <summary>
        /// 设置默认字体
        /// </summary>
        /// <param name="name">字体名称</param>
        public IImageWrapper DefaultFontName( string name ) {
            _defaultFontName = name;
            return this;
        }

        #endregion

        #region Font

        /// <inheritdoc />
        public IImageWrapper Font( float size, FontStyle style = FontStyle.Regular, string fontName = null ) {
            if ( fontName.IsEmpty() )
                fontName = _defaultFontName;
            var fontFamily = ImageManager.GetFont( fontName );
            _font = new Font( fontFamily, size, style );
            return this;
        }

        /// <inheritdoc />
        public IImageWrapper Font( float size, string fontName ) {
            return Font( size, FontStyle.Regular, fontName );
        }

        #endregion

        #region Text

        /// <inheritdoc />
        public IImageWrapper Text( string text, string color, float x, float y ) {
            _commands.Add( new TextCommand( _font, text, color, x, y ) );
            return this;
        }

        /// <inheritdoc />
        public IImageWrapper Text( string text, string color, TextOptions options ) {
            _commands.Add( new TextCommand( options, text, color ) );
            return this;
        }

        #endregion

        #region TextCenter

        /// <inheritdoc />
        public IImageWrapper TextCenter( string text, string color ) {
            var options = new TextOptions( _font ) {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Origin = new Vector2( _width / 2, _height / 2 )
            };
            return Text( text, color, options );
        }

        #endregion

        #region SaveAsync

        /// <inheritdoc />
        public async Task SaveAsync( string path, CancellationToken cancellationToken = default ) {
            using var image = GetImage();
            _commands.ForEach( command => command.Invoke( image ) );
            Util.Helpers.File.CreateDirectory( path );
            await image.SaveAsync( path, GetImageEncoder(), cancellationToken );
        }

        /// <summary>
        /// 获取图片实例
        /// </summary>
        protected Image GetImage() {
            if ( _loadPath.IsEmpty() )
                return new Image<Rgba32>( _width, _height, GetColor( _backgroundColor ) );
            return Image.Load( _loadPath );
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <param name="color">颜色值</param>
        protected Color GetColor( string color ) {
            return Color.ParseHex( color );
        }

        /// <summary>
        /// 获取图片编码器
        /// </summary>
        private IImageEncoder GetImageEncoder() {
            switch ( _imageType ) {
                case Images.ImageType.Png:
                    return new PngEncoder();
                case Images.ImageType.Gif:
                    return new GifEncoder();
                case Images.ImageType.Bmp:
                    return new BmpEncoder();
                case Images.ImageType.Jpg:
                    return new JpegEncoder();
                default:
                    return new PngEncoder();
            }
        }

        #endregion

        #region ToStreamAsync

        /// <inheritdoc />
        public async Task<byte[]> ToStreamAsync( CancellationToken cancellationToken = default ) {
            using var image = GetImage();
            using var stream = new MemoryStream();
            _commands.ForEach( command => command.Invoke( image ) );
            await image.SaveAsync( stream, GetImageEncoder(), cancellationToken );
            return await Util.Helpers.File.ToBytesAsync( stream ) ;
        }

        #endregion

        #region ToBase64

        /// <inheritdoc />
        public string ToBase64() {
            using var image = GetImage();
            _commands.ForEach( command => command.Invoke( image ) );
            return image.ToBase64String( GetImageFormat() );
        }

        /// <summary>
        /// 获取图片格式
        /// </summary>
        private IImageFormat GetImageFormat() {
            switch ( _imageType ) {
                case Images.ImageType.Png:
                    return PngFormat.Instance;
                case Images.ImageType.Gif:
                    return GifFormat.Instance;
                case Images.ImageType.Bmp:
                    return BmpFormat.Instance;
                case Images.ImageType.Jpg:
                    return JpegFormat.Instance;
                default:
                    return PngFormat.Instance;
            }
        }

        #endregion
    }
}
