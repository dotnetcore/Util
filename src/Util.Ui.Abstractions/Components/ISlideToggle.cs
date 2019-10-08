using Util.Ui.Operations;
using Util.Ui.Operations.Bind;
using Util.Ui.Operations.Events;
using Util.Ui.Operations.Forms;
using Util.Ui.Operations.Forms.Validations;
using Util.Ui.Operations.Layouts;
using Util.Ui.Operations.Styles;

namespace Util.Ui.Components {
    /// <summary>
    /// 滑动开关
    /// </summary>
    public interface ISlideToggle : IComponent, IName, ILabel, IDisabled, IModel, IRequired, IOnChange, ILabelPosition, IColor, IColspan,
        IStandalone, IBindName {
    }
}