using Util.Dependency;

namespace Util.Tools.QrCode {
    /// <summary>
    /// 二维码服务
    /// </summary>
    public interface IQrCodeService : IScopeDependency{
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
        /// 创建二维码
        /// </summary>
        /// <param name="content">内容</param>
        byte[] CreateQrCode( string content );
    }
}
