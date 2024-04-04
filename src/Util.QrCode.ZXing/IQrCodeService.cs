using Util.Images;

namespace Util.QrCode;

/// <summary>
/// 二维码服务
/// </summary>
public interface IQrCodeService : ITransientDependency {
    /// <summary>
    /// 设置二维码内容
    /// </summary>
    /// <param name="content">二维码内容</param>
    IQrCodeService Content( string content );
    /// <summary>
    /// 设置二维码尺寸
    /// </summary>
    /// <param name="size">二维码尺寸</param>
    IQrCodeService Size( QrSize size );
    /// <summary>
    /// 设置二维码尺寸
    /// </summary>
    /// <param name="size">二维码尺寸</param>
    IQrCodeService Size( int size );
    /// <summary>
    /// 容错处理
    /// </summary>
    /// <param name="level">容错级别</param>
    IQrCodeService Correction( ErrorCorrectionLevel level );
    /// <summary>
    /// 设置图片类型
    /// </summary>
    /// <param name="type">图片类型</param>
    IQrCodeService ImageType( ImageType type );
    /// <summary>
    /// 设置前景色
    /// </summary>
    /// <param name="color">前景色</param>
    IQrCodeService Color( Color color );
    /// <summary>
    /// 设置背景色
    /// </summary>
    /// <param name="color">背景色</param>
    IQrCodeService BgColor( Color color );
    /// <summary>
    /// 设置边距
    /// </summary>
    /// <param name="margin">边距,单位:像素</param>
    IQrCodeService Margin( int margin );
    /// <summary>
    /// 设置图标
    /// </summary>
    /// <param name="path">图标绝对路径</param>
    IQrCodeService Icon( string path );
    /// <summary>
    /// 获取二维码流
    /// </summary>
    Stream ToStream();
    /// <summary>
    /// 获取二维码字节流
    /// </summary>
    byte[] ToBytes();
    /// <summary>
    /// 获取二维码Base64字符串
    /// </summary>
    string ToBase64();
    /// <summary>
    /// 保存二维码图片
    /// </summary>
    /// <param name="path">文件绝对路径</param>
    void Save( string path );
    /// <summary>
    /// 获取二维码流
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task<Stream> ToStreamAsync( CancellationToken cancellationToken = default );
    /// <summary>
    /// 获取二维码字节流
    /// </summary>
    Task<byte[]> ToBytesAsync( CancellationToken cancellationToken = default );
    /// <summary>
    /// 保存二维码图片
    /// </summary>
    /// <param name="path">文件绝对路径</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task SaveAsync( string path, CancellationToken cancellationToken = default );
}