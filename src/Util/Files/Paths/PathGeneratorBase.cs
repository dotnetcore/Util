using System;
using System.IO;
using Util.Helpers;
using Util.Randoms;

namespace Util.Files.Paths {
    /// <summary>
    /// 路径生成器
    /// </summary>
    public abstract class PathGeneratorBase : IPathGenerator {
        /// <summary>
        /// 随机数生成器
        /// </summary>
        private readonly IRandomGenerator _randomGenerator;

        /// <summary>
        /// 初始化路径生成器
        /// </summary>
        /// <param name="randomGenerator">随机数生成器</param>
        protected PathGeneratorBase( IRandomGenerator randomGenerator ) {
            _randomGenerator = randomGenerator ?? GuidRandomGenerator.Instance;
        }

        /// <summary>
        /// 生成完整路径
        /// </summary>
        /// <param name="fileName">文件名，必须包含扩展名，如果仅传入扩展名则生成随机文件名</param>
        public string Generate( string fileName ) {
            if( string.IsNullOrWhiteSpace( fileName ) )
                throw new ArgumentNullException( nameof( fileName ) );
            return GeneratePath( GetFileName( fileName ) );
        }

        /// <summary>
        /// 创建完整路径
        /// </summary>
        /// <param name="fileName">被处理过的安全有效的文件名</param>
        protected abstract string GeneratePath( string fileName );

        /// <summary>
        /// 获取文件名
        /// </summary>
        private string GetFileName( string fileName ) {
            var name = Path.GetFileNameWithoutExtension( fileName );
            var extension = Path.GetExtension( fileName )?.TrimStart( '.' );
            if( string.IsNullOrWhiteSpace( extension ) ) {
                extension = fileName;
                name = string.Empty;
            }
            if( string.IsNullOrWhiteSpace( name ) )
                name = _randomGenerator.Generate();
            name = FilterFileName( name );
            return $"{name}-{Time.GetDateTime():HHmmss}.{extension}";
        }

        /// <summary>
        /// 过滤文件名
        /// </summary>
        private static string FilterFileName( string fileName ) {
            fileName = Regex.Replace( fileName, "\\W", "" );
            return Util.Helpers.String.PinYin( fileName );
        }
    }
}
