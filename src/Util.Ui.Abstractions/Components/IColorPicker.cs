using Util.Ui.Operations;
using Util.Ui.Operations.Bind;
using Util.Ui.Operations.Events;
using Util.Ui.Operations.Forms;

namespace Util.Ui.Components {
    /// <summary>
    /// 颜色选择器
    /// </summary>
    public interface IColorPicker : IComponent, IName, IDisabled, IModel, IOnChange,
        IStandalone, IBindName {
    }
}