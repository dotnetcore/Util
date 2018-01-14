using Util.Ui.Builders;

namespace Util.Ui.Material.Commons.Builders {
    /// <summary>
    /// angular模板生成器
    /// </summary>
    public class TemplateBuilder : TagBuilder {
        /// <summary>
        /// 初始化angular模板生成器
        /// </summary>
        public TemplateBuilder() : base( "ng-template" ) {
        }
    }
}
