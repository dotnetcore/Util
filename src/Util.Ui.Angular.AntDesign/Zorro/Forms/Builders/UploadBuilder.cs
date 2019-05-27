using Util.Ui.Builders;

namespace Util.Ui.Zorro.Forms.Builders {
    /// <summary>
    /// NgZorro文件上传生成器
    /// </summary>
    public class UploadBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro文件上传生成器
        /// </summary>
        public UploadBuilder( ) : base( "nz-upload" ) {
        }

        /// <summary>
        /// 添加nzAccept
        /// </summary>
        /// <param name="value">值</param>
        public void Accept( string value ) {
            AddAttribute( "nzAccept", value );
        }

        /// <summary>
        /// 添加nzFileType
        /// </summary>
        /// <param name="value">值</param>
        public void FileType( string value ) {
            AddAttribute( "nzFileType", value );
        }
    }
}
