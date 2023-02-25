using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace Util.Images.Commands {
    /// <summary>
    /// 文本命令
    /// </summary>
    public class TextCommand : ICommand {
        /// <summary>
        /// 初始化文本命令
        /// </summary>
        /// <param name="font">字体</param>
        /// <param name="text">文本</param>
        /// <param name="color">颜色</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        public TextCommand( Font font, string text, string color, float x, float y ) {
            Font = font;
            Text = text;
            Color = color;
            X = x;
            Y = y;
        }

        /// <summary>
        /// 初始化文本命令
        /// </summary>
        /// <param name="options">文本配置</param>
        /// <param name="text">文本</param>
        /// <param name="color">颜色</param>
        public TextCommand( TextOptions options, string text, string color ) {
            Options = options;
            Text = text;
            Color = color;
        }

        /// <summary>
        /// 字体
        /// </summary>
        public Font Font { get; }
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; }
        /// <summary>
        /// x坐标
        /// </summary>
        public float X { get; }
        /// <summary>
        /// y坐标
        /// </summary>
        public float Y { get; }
        /// <summary>
        /// 文本配置
        /// </summary>
        public TextOptions Options { get; }

        /// <inheritdoc />
        public void Invoke( Image image ) {
            image.CheckNull( nameof( image ) );
            if ( Options == null ) {
                image.Mutate( x => x.DrawText( Text, Font, SixLabors.ImageSharp.Color.ParseHex( Color ), new PointF( X, Y ) ) );
                return;
            }
            image.Mutate( x => x.DrawText( Options, Text, SixLabors.ImageSharp.Color.ParseHex( Color ) ) );
        }
    }
}
