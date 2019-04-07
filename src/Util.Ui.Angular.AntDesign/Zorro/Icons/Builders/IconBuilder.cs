using Util.Ui.Builders;

namespace Util.Ui.Zorro.Icons.Builders {
    /// <summary>
    /// 图标生成器
    /// </summary>
    public class IconBuilder : TagBuilder {
        /// <summary>
        /// 初始化图标生成器
        /// </summary>
        public IconBuilder() : base( "i" ) {
            AddAttribute( "nz-icon" );
        }

        /// <summary>
        /// 添加图标类型
        /// </summary>
        /// <param name="value">图标类型</param>
        public void AddType( string value ) {
            AddAttribute( "nzType", value );
        }

        /// <summary>
        /// 添加图标类型
        /// </summary>
        /// <param name="value">图标类型</param>
        public void AddBindType( string value ) {
            AddAttribute( "[nzType]", value );
        }
    }
}
