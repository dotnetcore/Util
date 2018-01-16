using Util.Ui.Operations;
using Util.Ui.Operations.Events;
using Util.Ui.Operations.Forms;
using Util.Ui.Operations.Forms.Validations;

namespace Util.Ui.Components {
    /// <summary>
    /// 复选框
    /// </summary>
    public interface ICheckBox : IComponent, IName,IText, IDisabled, IModel, IRequired, IOnChange {
    }
}
