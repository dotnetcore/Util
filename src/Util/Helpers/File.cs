using System.IO;
using System.Text;

namespace Util.Helpers {
    /// <summary>
    /// 文件和流操作
    /// </summary>
    public static class File {
        /// <summary>
        /// 流转换成字符串
        /// </summary>
        /// <param name="stream">流</param>
        public static string ToString( Stream stream ) {
            return ToString( stream, Encoding.UTF8 );
        }

        /// <summary>
        /// 流转换成字符串
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="encoding">字符编码</param>
        public static string ToString( Stream stream, Encoding encoding ) {
            if( stream == null )
                return string.Empty;
            if( stream.CanRead == false )
                return string.Empty;
            using( var reader = new StreamReader( stream, encoding ) ) {
                if( stream.CanSeek )
                    stream.Seek( 0, SeekOrigin.Begin );
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 复制流并转换成字符串
        /// </summary>
        /// <param name="stream">流</param>
        public static string CopyToString( Stream stream ) {
            return CopyToString( stream, Encoding.UTF8 );
        }

        /// <summary>
        /// 复制流并转换成字符串
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="encoding">字符编码</param>
        public static string CopyToString( Stream stream, Encoding encoding ) {
            if( stream == null )
                return string.Empty;
            if( stream.CanRead == false )
                return string.Empty;
            using ( var memoryStream = new MemoryStream() ) {
                using( var reader = new StreamReader( memoryStream, encoding ) ) {
                    if( stream.CanSeek )
                        stream.Seek( 0, SeekOrigin.Begin );
                    stream.CopyTo( memoryStream );
                    if( memoryStream.CanSeek )
                        memoryStream.Seek( 0, SeekOrigin.Begin );
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
