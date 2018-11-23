using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Util.Helpers {
    /// <summary>
    /// 文件和流操作
    /// </summary>
    public static class File {
        /// <summary>
        /// 流转换成字符串
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="bufferSize">缓冲区大小</param>
        /// <param name="isCloseStream">读取完成是否释放流，默认为true</param>
        public static string ToString( Stream stream, Encoding encoding = null, int bufferSize = 1024 * 2, bool isCloseStream = true ) {
            if( stream == null )
                return string.Empty;
            if( encoding == null )
                encoding = Encoding.UTF8;
            if( stream.CanRead == false )
                return string.Empty;
            using( var reader = new StreamReader( stream, encoding, true, bufferSize, !isCloseStream ) ) {
                if( stream.CanSeek )
                    stream.Seek( 0, SeekOrigin.Begin );
                var result = reader.ReadToEnd();
                if( stream.CanSeek )
                    stream.Seek( 0, SeekOrigin.Begin );
                return result;
            }
        }

        /// <summary>
        /// 流转换成字符串
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="bufferSize">缓冲区大小</param>
        /// <param name="isCloseStream">读取完成是否释放流，默认为true</param>
        public static async Task<string> ToStringAsync( Stream stream, Encoding encoding = null,int bufferSize = 1024 * 2, bool isCloseStream = true ) {
            if( stream == null )
                return string.Empty;
            if( encoding == null )
                encoding = Encoding.UTF8;
            if( stream.CanRead == false )
                return string.Empty;
            using( var reader = new StreamReader( stream, encoding, true, bufferSize, !isCloseStream ) ) {
                if( stream.CanSeek )
                    stream.Seek( 0, SeekOrigin.Begin );
                var result = await reader.ReadToEndAsync();
                if( stream.CanSeek )
                    stream.Seek( 0, SeekOrigin.Begin );
                return result;
            }
        }

        /// <summary>
        /// 复制流并转换成字符串
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="encoding">字符编码</param>
        public static async Task<string> CopyToStringAsync( Stream stream, Encoding encoding = null ) {
            if( stream == null )
                return string.Empty;
            if( encoding == null )
                encoding = Encoding.UTF8;
            if( stream.CanRead == false )
                return string.Empty;
            using( var memoryStream = new MemoryStream() ) {
                using( var reader = new StreamReader( memoryStream, encoding ) ) {
                    if( stream.CanSeek )
                        stream.Seek( 0, SeekOrigin.Begin );
                    stream.CopyTo( memoryStream );
                    if( memoryStream.CanSeek )
                        memoryStream.Seek( 0, SeekOrigin.Begin );
                    var result = await reader.ReadToEndAsync();
                    if( stream.CanSeek )
                        stream.Seek( 0, SeekOrigin.Begin );
                    return result;
                }
            }
        }
    }
}
