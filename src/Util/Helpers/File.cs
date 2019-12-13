using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Util.Helpers {
    /// <summary>
    /// 文件和流操作
    /// </summary>
    public static partial class File {
        /// <summary>
        /// 流转换为字节流
        /// </summary>
        /// <param name="stream">流</param>
        public static async Task<byte[]> ToBytesAsync( Stream stream ) {
            stream.Seek( 0, SeekOrigin.Begin );
            var buffer = new byte[stream.Length];
            await stream.ReadAsync( buffer, 0, buffer.Length );
            return buffer;
        }

        /// <summary>
        /// 流转换为字节流
        /// </summary>
        /// <param name="stream">流</param>
        public static byte[] ToBytes( Stream stream ) {
            stream.Seek( 0, SeekOrigin.Begin );
            var buffer = new byte[stream.Length];
            stream.Read( buffer, 0, buffer.Length );
            return buffer;
        }

        /// <summary>
        /// 字符串转换成字节数组
        /// </summary>
        /// <param name="data">数据,默认字符编码utf-8</param>        
        public static byte[] ToBytes( string data ) {
            return ToBytes( data, Encoding.UTF8 );
        }

        /// <summary>
        /// 字符串转换成字节数组
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="encoding">字符编码</param>
        public static byte[] ToBytes( string data, Encoding encoding ) {
            if( string.IsNullOrWhiteSpace( data ) )
                return new byte[] { };
            return encoding.GetBytes( data );
        }

        /// <summary>
        /// 将文件读取到字节流中
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static byte[] Read( string filePath ) {
            if( !System.IO.File.Exists( filePath ) )
                return null;
            var fileInfo = new FileInfo( filePath );
            using( var reader = new BinaryReader( fileInfo.Open( FileMode.Open ) ) ) {
                return reader.ReadBytes( (int)fileInfo.Length );
            }
        }

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
