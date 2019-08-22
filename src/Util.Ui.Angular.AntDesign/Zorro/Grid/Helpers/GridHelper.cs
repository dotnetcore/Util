using Util.Ui.Configs;
using Util.Ui.Zorro.Grid.Configs;

namespace Util.Ui.Zorro.Grid.Helpers {
    /// <summary>
    /// 栅格操作
    /// </summary>
    public class GridHelper {
        /// <summary>
        /// 获取栅格共享配置
        /// </summary>
        public static GridShareConfig GetShareConfig( IConfig config ) {
            return config.GetValueFromItems<GridShareConfig>();
        }

        /// <summary>
        /// 是否启用栅格布局
        /// </summary>
        public static bool EnabelGrid( IConfig config ) {
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
        public static string GetGutter( IConfig config ) {
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
        public static string GetControlSpan( IConfig config ) {
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
        public static string GetLabelSpan( IConfig config ) {
            var result = config.GetValue( UiConst.LabelSpan );
            if( result.IsEmpty() == false )
                return result;
            var shareConfig = GetShareConfig( config );
            return shareConfig?.LabelSpan;
        }
    }
}
