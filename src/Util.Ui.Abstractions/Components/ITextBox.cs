using Util.Ui.Operations.Forms;
using Util.Ui.Operations.Forms.Validations;

namespace Util.Ui.Components {
    /// <summary>
    /// 文本框
    /// </summary>
    public interface ITextBox : IFormControl, IReadOnly, IMinLength, IMaxLength,IMin,IMax, IRegex {
    }
}
