using Util.Ui.Operations;
using Util.Ui.Operations.Events;
using Util.Ui.Operations.Styles;

namespace Util.Ui.Components {
    /// <summary>
    /// 按钮
    /// </summary>
    public interface IButton : IText, IDisabled, IColor, ITooltip, IButtonStyle, IOnClick {
    }
}
