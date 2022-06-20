using System.Text;

namespace Util.Data.Sql.Builders {
    /// <summary>
    /// Sql内容
    /// </summary>
    public interface ISqlContent {
        /// <summary>
        /// 添加到字符串生成器
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        void AppendTo( StringBuilder builder );
    }
}
