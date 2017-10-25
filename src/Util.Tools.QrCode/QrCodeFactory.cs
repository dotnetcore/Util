using Util.Files;
using Util.Files.Paths;
using Util.Tools.QrCode.QrCoder;

namespace Util.Tools.QrCode {
    /// <summary>
    /// 二维码服务工厂
    /// </summary>
    public static class QrCodeFactory {
        /// <summary>
        /// 创建二维码服务
        /// </summary>
        /// <param name="path">二维码文件存储目录</param>
        public static IQrCodeService Create( string path ) {
            return new QrCoderService( new DefaultFileStore( new DefaultPathGenerator( path ) ) );
        }
    }
}
