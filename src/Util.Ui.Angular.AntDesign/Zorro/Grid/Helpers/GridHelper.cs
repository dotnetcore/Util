using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Grid.Configs;

namespace Util.Ui.Zorro.Grid.Helpers {
    /// <summary>
    /// 栅格操作
    /// </summary>
    public class GridHelper {
        /// <summary>
        /// 获取栅格共享配置
        /// </summary>
        public static GridShareConfig GetShareConfig( Config config ) {
            return config.Context?.GetValueFromItems<GridShareConfig>( GridShareConfig.Key );
        }

        /// <summary>
        /// 是否启用栅格布局
        /// </summary>
        public static bool EnabelGrid( Config config ) {
            if( config.Contains( UiConst.Span ) )
                return true;
            var shareConfig = GetShareConfig( config );
            if( shareConfig == null )
                return false;
            if( shareConfig.ControlSpan.IsEmpty() == false )
                return true;
            return false;
        }

        /// <summary>
        /// 获取间隔
        /// </summary>
        /// <param name="config">配置</param>
        public static string GetGutter( Config config ) {
            var result = config.GetValue( UiConst.Gutter );
            if ( result.IsEmpty() == false )
                return result;
            var shareConfig = GetShareConfig( config );
            return shareConfig?.Gutter;
        }

        /// <summary>
        /// 获取控件跨度
        /// </summary>
        /// <param name="config">配置</param>
        public static string GetControlSpan( Config config ) {
            var result = config.GetValue( UiConst.Span );
            if( result.IsEmpty() == false )
                return result;
            var shareConfig = GetShareConfig( config );
            return shareConfig?.ControlSpan;
        }

        /// <summary>
        /// 获取标签跨度
        /// </summary>
        /// <param name="config">配置</param>
        public static string GetLabelSpan( Config config ) {
            var result = config.GetValue( UiConst.LabelSpan );
            if( result.IsEmpty() == false )
                return result;
            var shareConfig = GetShareConfig( config );
            return shareConfig?.LabelSpan;
        }
    }
}
