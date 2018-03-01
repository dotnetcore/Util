using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Material.Grids;
using Util.Ui.Operations.Layouts;

namespace Util.Ui.Material.Extensions {
    /// <summary>
    /// 布局扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置栅格合并列
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="colspan">合并列</param>
        /// <param name="afterColspan">右边占位合并列</param>
        /// <param name="beforeColspan">左边占位合并列</param>
        public static TComponent Colspan<TComponent>( this TComponent component,int? colspan = null, int? afterColspan = null, int? beforeColspan = null ) where TComponent : IColspan {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Colspan, colspan );
                if( beforeColspan > 0 )
                    config.SetAttribute( UiConst.BeforeColspan, beforeColspan );
                if( afterColspan > 0 )
                    config.SetAttribute( UiConst.AfterColspan, afterColspan );
            } );
            return component;
        }

        /// <summary>
        /// 设置列数
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="columns">列数</param>
        public static TComponent Columns<TComponent>( this TComponent component,int columns ) where TComponent : IGrid {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.Columns, columns );
            } );
            return component;
        }

        /// <summary>
        /// 设置行高
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="rowHeight">行高，可指定单位，如果仅传入数值，则单位为px</param>
        public static TComponent RowHeight<TComponent>( this TComponent component, string rowHeight ) where TComponent : IGrid {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.RowHeight, rowHeight );
            } );
            return component;
        }

        /// <summary>
        /// 设置单元格间距
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="gutterSize">单元格间距，可指定单位，如果仅传入数值，则单位为px</param>
        public static TComponent GutterSize<TComponent>( this TComponent component, string gutterSize ) where TComponent : IGrid {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( MaterialConst.GutterSize, gutterSize );
            } );
            return component;
        }

        /// <summary>
        /// 添加栅格合并列设置
        /// </summary>
        /// <typeparam name="TConfig">配置类型</typeparam>
        /// <param name="config">配置实例</param>
        /// <param name="gridConfig">栅格配置</param>
        public static void AddColspan<TConfig>( this TConfig config, IConfig gridConfig ) where TConfig : IConfig {
            if ( gridConfig == null )
                return;
            if ( gridConfig.Contains( UiConst.Colspan ) == false )
                return;
            config.SetAttribute( UiConst.Colspan, gridConfig.GetValue<int?>( UiConst.Colspan ) );
            var beforeColspan = gridConfig.GetValue<int?>( UiConst.BeforeColspan );
            var afterColspan = gridConfig.GetValue<int?>( UiConst.AfterColspan );
            if( beforeColspan > 0 )
                config.SetAttribute( UiConst.BeforeColspan, beforeColspan );
            if( afterColspan > 0 )
                config.SetAttribute( UiConst.AfterColspan, afterColspan );
        }
    }
}
