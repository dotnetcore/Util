using System;
using System.Collections.Generic;
using System.IO;
using Util.Randoms;

namespace Util.Files.Paths {
    /// <summary>
    /// 路径生成器
    /// </summary>
    public abstract class PathGeneratorBase : IPathGenerator {
        /// <summary>
        /// 路径参数
        /// </summary>
        protected Dictionary<string, string> Parameters { get; }

        /// <summary>
        /// 随机数生成器
        /// </summary>
        private readonly IRandomGenerator _randomGenerator;

        /// <summary>
        /// 初始化路径生成器
        /// </summary>
        /// <param name="randomGenerator">随机数生成器</param>
        protected PathGeneratorBase( IRandomGenerator randomGenerator ) {
            Parameters = new Dictionary<string, string>();
            _randomGenerator = randomGenerator ?? GuidRandomGenerator.Instance;
        }

        /// <summary>
        /// 添加路径参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public IPathGenerator Data( string key, string value ) {
            if( string.IsNullOrWhiteSpace( key ) )
                return this;
            if( Parameters.ContainsKey( key ) )
                return this;
            Parameters[key] = value;
            return this;
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
            var extension = Path.GetExtension( fileName ).TrimStart( '.' );
            if( string.IsNullOrWhiteSpace( extension ) ) {
                extension = fileName;
                name = string.Empty;
            }
            if( string.IsNullOrWhiteSpace( name ) )
                name = _randomGenerator.Generate();
            return $"{name}.{extension}";
        }
    }
}
