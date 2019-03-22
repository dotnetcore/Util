using Util.Ui.CkEditor;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;

namespace Util.Ui.Extensions {
    /// <summary>
    /// CKEditor扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 上传
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="url">上传地址</param>
        public static TComponent Upload<TComponent>( this TComponent component,string url ) where TComponent : IEditor {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.SetAttribute( UiConst.UploadUrl, url );
            } );
            return component;
        }
    }
}
