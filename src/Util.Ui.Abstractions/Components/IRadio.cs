using Util.Ui.Operations;
using Util.Ui.Operations.Bind;
using Util.Ui.Operations.Datas;
using Util.Ui.Operations.Events;
using Util.Ui.Operations.Forms;
using Util.Ui.Operations.Forms.Validations;
using Util.Ui.Operations.Layouts;

namespace Util.Ui.Components {
    /// <summary>
    /// 单选框
    /// </summary>
    public interface IRadio : IComponent, IName, ILabel, IDisabled, IModel, IRequired, IOnChange, ILabelPosition, IUrl, IDataSource, IItem, IColspan,
        IStandalone, IBindName {
        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        IRadio Enum<TEnum>();
    }
}
