using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Util.Datas.Transactions {
    /// <summary>
    /// 事务操作管理器
    /// </summary>
    public class TransactionActionManager : ITransactionActionManager {
        /// <summary>
        /// 操作列表
        /// </summary>
        private readonly List<Func<IDbTransaction, Task>> _actions;

        /// <summary>
        /// 初始化事务操作管理器
        /// </summary>
        public TransactionActionManager() {
            _actions = new List<Func<IDbTransaction, Task>>();
        }

        /// <summary>
        /// 事务操作数量
        /// </summary>
        public int Count => _actions.Count;

        /// <summary>
        /// 注册事务操作
        /// </summary>
        /// <param name="action">事务操作</param>
        public void Register( Func<IDbTransaction, Task> action ) {
            if( action == null )
                return;
            _actions.Add( action );
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="transaction">事务</param>
        public async Task CommitAsync( IDbTransaction transaction ) {
            foreach( var action in _actions )
                await action( transaction );
            _actions.Clear();
        }
    }
}
