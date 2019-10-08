using System;
using Util.Ui.Components;
using Util.Ui.Operations.Events;

namespace Util.Ui.Material.Forms {
    /// <summary>
    /// 表单
    /// </summary>
    public interface IForm : IContainer<IDisposable>, IOnSubmit {
    }
}
