using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Zorro.Grid.Helpers {
    /// <summary>
    /// 表单控件栅格配置操作
    /// </summary>
    public class FormControlGridConfig : GridConfig {
        /// <summary>
        /// 初始化表单控件栅格配置操作
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public FormControlGridConfig( TagBuilder builder, Config config ) : base( builder, config ) {
        }

        /// <summary>
        /// 获取span的键名
        /// </summary>
        protected override string GetSpanName() {
            return "[nzSpan]";
        }
    }
}
