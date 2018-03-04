using Util.Ui.Components;
using Util.Ui.Operations;
using Util.Ui.Operations.Datas;
using Util.Ui.Operations.Events;
using Util.Ui.Operations.Forms;
using Util.Ui.Operations.Layouts;

namespace Util.Ui.Material.Lists {
    /// <summary>
    /// 选择列表
    /// </summary>
    public interface ISelectList : IComponent, IName, IDisabled, IModel, IOnChange, IColspan, IUrl, IDataSource, IItem,ILabel {
        /// <summary>
        /// 绑定枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        ISelectList Enum<TEnum>();
    }
}