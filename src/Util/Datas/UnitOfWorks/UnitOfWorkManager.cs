using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Util.Datas.UnitOfWorks {
    /// <summary>
    /// 工作单元服务
    /// </summary>
    public class UnitOfWorkManager : IUnitOfWorkManager {
        /// <summary>
        /// 工作单元集合
        /// </summary>
        private readonly List<IUnitOfWork> _unitOfWorks;

        /// <summary>
        /// 初始化工作单元服务
        /// </summary>
        public UnitOfWorkManager() {
            _unitOfWorks = new List<IUnitOfWork>();
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Commit() {
            if( _unitOfWorks.Count == 0 )
                return;
            if( _unitOfWorks.Count == 1 ) {
                _unitOfWorks[0].Commit();
                return;
            }
            using( var scope = new TransactionScope() ) {
                _unitOfWorks.ForEach( unitOfWork => unitOfWork.Commit() );
                scope.Complete();
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        public async Task CommitAsync() {
            if( _unitOfWorks.Count == 0 )
                return;
            if( _unitOfWorks.Count == 1 ) {
                await _unitOfWorks[0].CommitAsync();
                return;
            }
            using( var scope = new TransactionScope() ) {
                foreach( var unitOfWork in _unitOfWorks )
                    await unitOfWork.CommitAsync();
                scope.Complete();
            }
        }

        /// <summary>
        /// 注册工作单元
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public void Register( IUnitOfWork unitOfWork ) {
            if( unitOfWork == null )
                throw new ArgumentNullException( nameof( unitOfWork ) );
            if( _unitOfWorks.Contains( unitOfWork ) == false )
                _unitOfWorks.Add( unitOfWork );
        }
    }
}
