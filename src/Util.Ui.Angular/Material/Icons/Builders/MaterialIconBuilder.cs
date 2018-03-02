using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;

namespace Util.Ui.Material.Icons.Builders {
    /// <summary>
    /// Material图标生成器
    /// </summary>
    public class MaterialIconBuilder : TagBuilder {
        /// <summary>
        /// 初始化图标生成器
        /// </summary>
        public MaterialIconBuilder() : base( "mat-icon" ) {
        }

        /// <summary>
        /// 设置图标
        /// </summary>
        /// <param name="config">配置</param>
        public void SetIcon( IConfig config) {
            SetContent( config.GetValue<MaterialIcon?>( UiConst.MaterialIcon )?.Description() );
        }

        /// <summary>
        /// 配置图标大小
        /// </summary>
        /// <param name="config">配置</param>
        public void SetSize( IConfig config ) {
            if( config.Contains( UiConst.Size ) )
                Class( config.GetValue<IconSize>( UiConst.Size ).Description() );
        }
    }
}
