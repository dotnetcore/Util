using Humanizer;

namespace Util.Generators.Contexts {
    /// <summary>
    /// 输出
    /// </summary>
    public class Output {
        /// <summary>
        /// 根路径
        /// </summary>
        public string RootPath { get; set; }
        /// <summary>
        /// 相对根路径
        /// </summary>
        public string RelativeRootPath { get; set; }
        /// <summary>
        /// 输出文件名,不包含扩展名
        /// </summary>
        public string FileNameNoExtension { get; set; }
        /// <summary>
        /// 输出文件扩展名,范例: ".txt"
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// 命名约定
        /// </summary>
        public NamingConvention? NamingConvention { get; set; }

        /// <summary>
        /// 输出路径
        /// </summary>
        public string Path {
            get {
                if( RelativeRootPath.IsEmpty() )
                    return System.IO.Path.Combine( RootPath, GetFileName() );
                return System.IO.Path.Combine( RootPath, RelativeRootPath, GetFileName() );
            }
        }

        /// <summary>
        /// 获取文件名
        /// </summary>
        private string GetFileName() {
            string result = null;
            if( NamingConvention == null )
                result = FileNameNoExtension;
            if( NamingConvention == Generators.NamingConvention.PascalCase )
                result = FileNameNoExtension.Pascalize();
            if( NamingConvention == Generators.NamingConvention.CamelCase )
                result = FileNameNoExtension.Camelize();
            return result + Extension;
        }

        /// <summary>
        /// 复制到输出副本
        /// </summary>
        /// <param name="copy">输出副本</param>
        public void CopyTo( Output copy ) {
            copy.CheckNull( nameof( copy ) );
            copy.RootPath = RootPath;
            copy.RelativeRootPath = RelativeRootPath;
            copy.FileNameNoExtension = FileNameNoExtension;
            copy.Extension = Extension;
            copy.NamingConvention = NamingConvention;
        }
    }
}
