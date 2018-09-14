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
            if ( stream.CanRead == false )
                return string.Empty;
            string result;
            using( var reader = new StreamReader( stream, encoding ) ) {
                if( reader.BaseStream.CanSeek )
                    reader.BaseStream.Position = 0;
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
