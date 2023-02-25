using System.Threading;
using System.Threading.Tasks;
using Util.Dependency;

namespace Util.Images {
    /// <summary>
    /// 头像服务
    /// </summary>
    public interface IAvatarManager : ITransientDependency{
        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <param name="color">背景色,默认值: 5d005d</param>
        IAvatarManager BackgroundColor( string color );
        /// <summary>
        /// 设置头像大小
        /// </summary>
        /// <param name="size">头像图片大小,单位:像素,值范围: 16 - 512,默认值: 64, 范例: 设置16,代表16*16的正方形图片</param>
        IAvatarManager Size( int size );
        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="fontName">字体名称,范例: </param>
        IAvatarManager Font( string fontName );
        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <param name="size">字体大小,值范围可以是16 - 512,单位:像素,值范围也可以是0.1 - 1,单位:百分比,默认值: 0.5,范例: 设置32,代表32像素,设置0.5,代表头像图片大小的一半</param>
        IAvatarManager FontSize( double size );
        /// <summary>
        /// 设置字体颜色
        /// </summary>
        /// <param name="color">字体颜色,默认值: ffffff</param>
        IAvatarManager FontColor( string color );
        /// <summary>
        /// 设置或取消字体粗体,默认值: false
        /// </summary>
        /// <param name="isBold">字体是否粗体</param>
        IAvatarManager Bold( bool isBold = true );
        /// <summary>
        /// 设置或取消字体斜体,默认值: false
        /// </summary>
        /// <param name="isItalic">字体是否斜体</param>
        IAvatarManager Italic( bool isItalic = true );
        /// <summary>
        /// 设置或取消字体大写,默认值: true
        /// </summary>
        /// <param name="isUppercase">字体是否大写</param>
        IAvatarManager Uppercase( bool isUppercase = true );
        /// <summary>
        /// 设置文本
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="length">文本长度,默认值: 1,范例:文本为abcd,设置2,显示ab</param>
        IAvatarManager Text( string text,int length = 1 );
        /// <summary>
        /// 保存到目标路径
        /// </summary>
        /// <param name="path">保存文件的绝对路径</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task SaveAsync( string path, CancellationToken cancellationToken = default );
        /// <summary>
        /// 转换为图片流
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        Task<byte[]> ToStreamAsync( CancellationToken cancellationToken = default );
        /// <summary>
        /// 转换为Base64字符串
        /// </summary>
        string ToBase64();
    }
}
