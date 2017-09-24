using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Util.Aspects.Base;
using Util.Datas.UnitOfWorks;

namespace Util.Datas.Ef.Aspects {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitOfWorkAttribute : InterceptorBase {
        /// <summary>
        /// 执行
        /// </summary>
        public override async Task Invoke( AspectContext context, AspectDelegate next ) {
            await next( context );
            var manager = context.ServiceProvider.GetService<IUnitOfWorkManager>();
            await manager.CommitAsync();
        }
    }
}
