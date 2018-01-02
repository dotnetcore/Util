using Util.Ui.Operations.Datas;
using Util.Ui.Operations.Events;
using Util.Ui.Operations.Forms;
using Util.Ui.Operations.Forms.Validations;

namespace Util.Ui.Components {
    /// <summary>
    /// 下拉列表
    /// </summary>
    public interface ISelect : IComponent, IUrl, IDataSource, IPlaceholder, IResetOption, IMultiple,IModel,IRequired, IOnChange {
        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        ISelect Enum<TEnum>();
    }
}