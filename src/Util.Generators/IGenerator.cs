using System.Threading.Tasks;

namespace Util.Generators {
    /// <summary>
    /// 生成器
    /// </summary>
    public interface IGenerator {
        /// <summary>
        /// 生成
        /// </summary>
        Task GenerateAsync();
    }
}
