using System.IO;
using Util.Ui.Components;
using Util.Ui.Material.Grids.Renders;
using Util.Ui.Material.Grids.Wrappers;
using Util.Ui.Renders;

namespace Util.Ui.Material.Grids {
    /// <summary>
    /// 栅格
    /// </summary>
    /// <typeparam name="TModel">模型类型</typeparam>
    public class Grid<TModel> : ContainerBase<IGridWrapper<TModel>>, IGrid<TModel> {
        /// <summary>
        /// 初始化栅格
        /// </summary>
        /// <param name="writer">流写入器</param>
        public Grid( TextWriter writer ) : base( writer ) {
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected override IRender GetRender() {
            return new GridRender( OptionConfig );
        }

        /// <summary>
        /// 获取容器包装器
        /// </summary>
        protected override IGridWrapper<TModel> GetWrapper() {
            return new GridWrapper<TModel>( this,OptionConfig );
        }
    }
}