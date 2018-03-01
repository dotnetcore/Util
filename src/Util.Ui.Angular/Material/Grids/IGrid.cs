using Util.Ui.Components;
using Util.Ui.Material.Grids.Wrappers;
using Util.Ui.Operations.Layouts;

namespace Util.Ui.Material.Grids {
    /// <summary>
    /// 栅格
    /// </summary>
    public interface IGrid {
    }

    /// <summary>
    /// 栅格
    /// </summary>
    public interface IGrid<TModel> : IContainer<IGridWrapper<TModel>>, IGrid,IColspan {
    }
}