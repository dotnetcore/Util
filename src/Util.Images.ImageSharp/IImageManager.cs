using Util.Dependency;

namespace Util.Images {
    /// <summary>
    /// 图片服务
    /// </summary>
    public interface IImageManager : ISingletonDependency {
        /// <summary>
        /// 创建图片
        /// </summary>
        /// <param name="width">宽度,单位:像素</param>
        /// <param name="height">高度,单位:像素</param>
        /// <param name="backgroundColor">背景色</param>
        IImageWrapper CreateImage( int width, int height,string backgroundColor = null );
        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="path">图片绝对路径</param>
        IImageWrapper LoadImage( string path );
    }
}
