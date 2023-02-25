using System.Threading;
using System.Threading.Tasks;
using SixLabors.Fonts;

namespace Util.Images {
    /// <summary>
    /// 图片操作包装器
    /// </summary>
    public interface IImageWrapper {
        /// <summary>
        /// 设置图片类型,默认值: Png
        /// </summary>
        /// <param name="type">图片类型</param>
        IImageWrapper ImageType( ImageType type );

        /// <summary>
        /// 设置默认字体
        /// </summary>
        /// <param name="name">字体名称</param>
        IImageWrapper DefaultFontName( string name );

        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="size">字体大小</param>
        /// <param name="style">字体样式</param>
        /// <param name="fontName">字体名称</param>
        IImageWrapper Font( float size, FontStyle style = FontStyle.Regular, string fontName = null );

        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="size">字体大小</param>
        /// <param name="fontName">字体名称</param>
        IImageWrapper Font( float size, string fontName );

        /// <summary>
        /// 写入文本
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="color">颜色</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        IImageWrapper Text( string text, string color, float x, float y );

        /// <summary>
        /// 写入文本
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="color">颜色</param>
        /// <param name="options">文本配置</param>
        IImageWrapper Text( string text, string color, TextOptions options );

        /// <summary>
        /// 写入文本并居中显示
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="color">颜色</param>
        IImageWrapper TextCenter( string text, string color );

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
