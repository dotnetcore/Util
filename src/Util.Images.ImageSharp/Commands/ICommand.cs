using SixLabors.ImageSharp;

namespace Util.Images.Commands {
    /// <summary>
    /// 调用命令
    /// </summary>
    public interface ICommand {
        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="image">图片实例</param>
        void Invoke( Image image );
    }
}
