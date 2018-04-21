using Util.Ui.Operations;
using Util.Ui.Operations.Bind;
using Util.Ui.Operations.Events;
using Util.Ui.Operations.Forms;
using Util.Ui.Operations.Forms.Validations;
using Util.Ui.Operations.Layouts;

namespace Util.Ui.Components {
    /// <summary>
    /// 表单控件
    /// </summary>
    public interface IFormControl : IComponent,IName,IDisabled, IPlaceholder, IHint, IPrefix, ISuffix, IModel, 
        IRequired, IOnChange, IOnFocus, IOnBlur, IOnKeyup, IOnKeydown, IColspan, IStandalone,
        IBindName {
    }
}