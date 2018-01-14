using Util.Ui.Operations;
using Util.Ui.Operations.Events;
using Util.Ui.Operations.Styles;

namespace Util.Ui.Components {
    /// <summary>
    /// 链接
    /// </summary>
    public interface IAnchor : IComponent, IText, IDisabled, IColor, ITooltip, IButtonStyle, IOnClick {
    }
}
