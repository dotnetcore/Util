using Util.Ui.Components;
using Util.Ui.Components.Internal;
using Util.Ui.Configs;
using Util.Ui.Operations.Forms;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 组件扩展 - 表单
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <typeparam name="TComponent">组件类型</typeparam>
        /// <param name="component">组件实例</param>
        /// <param name="model">模型名称</param>
        public static TComponent Model<TComponent>( this TComponent component, string model ) where TComponent : IComponent, IModel {
            var option = component as IOptionConfig;
            option?.Config<Config>( config => {
                config.Model = model;
            } );
            return component;
        }
    }
}
