using Util.Images;
using SixLabors.ImageSharp;
using CorrectionLevel = ZXing.QrCode.Internal.ErrorCorrectionLevel;

namespace Util.QrCode.ZXing;

/// <summary>
/// ZXing二维码服务
/// </summary>
public class ZXingQrCodeService : IQrCodeService {
    /// <summary>
    /// 内容
    /// </summary>
    private string _content;
    /// <summary>
    /// 二维码尺寸
    /// </summary>
    private int _size;
    /// <summary>
    /// 容错级别
    /// </summary>
    private CorrectionLevel _level;
    /// <summary>
    /// 图片类型
    /// </summary>
    private ImageType _imageType;
    /// <summary>
    /// 前景色
    /// </summary>
    private System.Drawing.Color _foreground;
    /// <summary>
    /// 背景色
    /// </summary>
    private System.Drawing.Color _background;
    /// <summary>
    /// 边距
    /// </summary>
    private int _margin;
    /// <summary>
    /// 图标路径
    /// </summary>
    private string _iconPath;

    /// <summary>
    /// 初始化二维码服务
    /// </summary>
    public ZXingQrCodeService() {
        _level = CorrectionLevel.L;
        _imageType = Images.ImageType.Png;
        _foreground = System.Drawing.Color.Black;
        _background = System.Drawing.Color.White;
        _margin = 0;
        Size( 160 );
    }

    /// <inheritdoc />
    public IQrCodeService Content( string content ) {
        _content = content;
        return this;
    }

    /// <inheritdoc />
    public IQrCodeService Size( QrSize size ) {
        return Size( size.Value().SafeValue() );
    }

    /// <inheritdoc />
    public IQrCodeService Size( int size ) {
        _size = size;
        return this;
    }

    /// <inheritdoc />
    public IQrCodeService Correction( ErrorCorrectionLevel level ) {
        switch ( level ) {
            case ErrorCorrectionLevel.L:
                _level = CorrectionLevel.L;
                break;
            case ErrorCorrectionLevel.M:
                _level = CorrectionLevel.M;
                break;
            case ErrorCorrectionLevel.Q:
                _level = CorrectionLevel.Q;
                break;
            case ErrorCorrectionLevel.H:
                _level = CorrectionLevel.H;
                break;
        }
        return this;
    }

    /// <inheritdoc />
    public IQrCodeService ImageType( ImageType type ) {
        _imageType = type;
        return this;
    }

    /// <inheritdoc />
    public IQrCodeService Color( System.Drawing.Color color ) {
        _foreground = color;
        return this;
    }

    /// <inheritdoc />
    public IQrCodeService BgColor( System.Drawing.Color color ) {
        _background = color;
        return this;
    }

    /// <inheritdoc />
    public IQrCodeService Margin( int margin ) {
        _margin = margin;
        return this;
    }

    /// <inheritdoc />
    public IQrCodeService Icon( string path ) {
        _iconPath = path;
        return this;
    }

    /// <inheritdoc />
    public Stream ToStream() {
        var bytes = ToBytes();
        return new MemoryStream( bytes );
    }

    /// <inheritdoc />
    public byte[] ToBytes() {
        using var image = GetImage();
        using var stream = new MemoryStream();
        image.Save( stream, GetImageEncoder() );
        return stream.ToArray();
    }

    /// <inheritdoc />
    public string ToBase64() {
        using var image = GetImage();
        return image.ToBase64String( GetImageFormat() );
    }

    /// <summary>
    /// 获取图片格式
    /// </summary>
    private IImageFormat GetImageFormat() {
        return ImageWrapper.GetImageFormat( _imageType );
    }

    /// <inheritdoc />
    public void Save( string path ) {
        if ( path.IsEmpty() )
            return;
        Util.Helpers.File.CreateDirectory( path );
        using var image = GetImage();
        image.Save( path, GetImageEncoder() );
    }

    /// <inheritdoc />
    public async Task<Stream> ToStreamAsync( CancellationToken cancellationToken = default ) {
        var bytes = await ToBytesAsync( cancellationToken );
        return new MemoryStream( bytes );
    }

    /// <inheritdoc />
    public async Task<byte[]> ToBytesAsync( CancellationToken cancellationToken = default ) {
        using var image = GetImage();
        using var stream = new MemoryStream();
        await image.SaveAsync( stream, GetImageEncoder(), cancellationToken );
        return stream.ToArray();
    }

    /// <summary>
    /// 获取二维码图片
    /// </summary>
    private Image GetImage() {
        if ( _content.IsEmpty() )
            throw new ArgumentException( "必须设置内容" );
        var writer = new BarcodeWriter<Image<Rgba32>> {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions {
                CharacterSet = "UTF-8",
                ErrorCorrection = _level,
                Margin = _margin,
                Width = _size,
                Height = _size
            },
            Renderer = new ImageSharpRenderer<Rgba32> {
                Foreground = _foreground.ToImageSharpColor(),
                Background = _background.ToImageSharpColor()
            }
        };
        var result = writer.Write( _content );
        return _iconPath.IsEmpty() ? result : MergeImage( result, Image.Load( _iconPath ) );
    }

    /// <summary>
    /// 合并图片
    /// </summary>
    private Image MergeImage( Image image, Image icon ) {
        var margin = 10 - _margin;
        if ( margin <= 0 )
            margin = 5;
        var width = ( image.Width * margin - 46 * margin ) * 1.0f / 46;
        icon.Zoom( width / icon.Width );
        icon.RoundCorners( 7 );
        image.RoundCorners( 7 );
        image.Mutate( x => {
            x.DrawImage( icon, new SixLabors.ImageSharp.Point( ( image.Width - icon.Width ) / 2, ( image.Height - icon.Height ) / 2 ), 1 );
        } );
        return image;
    }

    /// <summary>
    /// 获取图片编码器
    /// </summary>
    private IImageEncoder GetImageEncoder() {
        return ImageWrapper.GetImageEncoder( _imageType );
    }

    /// <inheritdoc />
    public async Task SaveAsync( string path, CancellationToken cancellationToken = default ) {
        if ( path.IsEmpty() )
            return;
        Util.Helpers.File.CreateDirectory( path );
        using var image = GetImage();
        await image.SaveAsync( path, GetImageEncoder(), cancellationToken );
    }
}