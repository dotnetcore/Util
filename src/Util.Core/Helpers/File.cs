using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Helpers {
    /// <summary>
    /// 文件流操作
    /// </summary>
    public static class File {
        /// <summary>
        /// 读取文件到字符串
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        public static string ReadToString( string filePath ) {
            return ReadToString( filePath, Encoding.UTF8 );
        }

        /// <summary>
        /// 读取文件到字符串
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="encoding">字符编码</param>
        public static string ReadToString( string filePath, Encoding encoding ) {
            if( System.IO.File.Exists( filePath ) == false )
                return string.Empty;
            using var reader = new StreamReader( filePath, encoding );
            return reader.ReadToEnd();
        }

        /// <summary>
        /// 读取文件到字符串
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        public static async Task<string> ReadToStringAsync( string filePath ) {
            return await ReadToStringAsync( filePath, Encoding.UTF8 );
        }

        /// <summary>
        /// 读取文件到字符串
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="encoding">字符编码</param>
        public static async Task<string> ReadToStringAsync( string filePath, Encoding encoding ) {
            if( System.IO.File.Exists( filePath ) == false )
                return string.Empty;
            using var reader = new StreamReader( filePath, encoding );
            return await reader.ReadToEndAsync();
        }

        /// <summary>
        /// 将字符串写入文件
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="content">内容</param>
        public static void Write( string filePath, string content ) {
            Write( filePath, Util.Helpers.Convert.ToBytes( content ) );
        }

        /// <summary>
        /// 将字节流写入文件
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="content">内容</param>
        public static void Write( string filePath, byte[] content ) {
            if( string.IsNullOrWhiteSpace( filePath ) )
                return;
            if( content == null )
                return;
            CreateDirectory( filePath );
            System.IO.File.WriteAllBytes( filePath, content );
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        private static void CreateDirectory( string filePath ) {
            var file = new FileInfo( filePath );
            if ( file.Directory?.Exists == true )
                return;
            System.IO.Directory.CreateDirectory( file.DirectoryName );
        }

        /// <summary>
        /// 将字符串写入文件
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="content">内容</param>
        public static async Task WriteAsync( string filePath, string content ) {
            await WriteAsync( filePath, Util.Helpers.Convert.ToBytes( content ) );
        }

        /// <summary>
        /// 将字节流写入文件
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="content">内容</param>
        public static async Task WriteAsync( string filePath, byte[] content ) {
            if( string.IsNullOrWhiteSpace( filePath ) )
                return;
            if( content == null )
                return;
            CreateDirectory( filePath );
            await System.IO.File.WriteAllBytesAsync( filePath, content );
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePaths">文件绝对路径集合</param>
        public static void Delete( IEnumerable<string> filePaths ) {
            foreach( var filePath in filePaths )
                Delete( filePath );
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        public static void Delete( string filePath ) {
            if( string.IsNullOrWhiteSpace( filePath ) )
                return;
            if( System.IO.File.Exists( filePath ) )
                System.IO.File.Delete( filePath );
        }

        /// <summary>
        /// 获取全部文件,包括所有子目录
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <param name="searchPattern">搜索模式</param>
        public static List<FileInfo> GetAllFiles( string path,string searchPattern ) {
            return Directory.GetFiles( path, searchPattern, SearchOption.AllDirectories )
                .Select( filePath => new FileInfo( filePath ) ).ToList();
        }
    }
}
