using System.Collections.Generic;
using System.Linq;

namespace Util.Tools.Offices.Core {
    /// <summary>
    /// 索引管理器
    /// </summary>
    public class IndexManager {
        /// <summary>
        /// 初始化索引管理器
        /// </summary>
        public IndexManager() {
            _list = new List<IndexRange> { new IndexRange( 0, 10000 ) };
        }

        /// <summary>
        /// 索引列表
        /// </summary>
        private readonly List<IndexRange> _list;

        /// <summary>
        /// 获取索引
        /// </summary>
        /// <param name="span">跨度</param>
        public int GetIndex( int span = 1 ) {
            var range = _list.First();
            var index = range.GetIndex( span );
            if ( range.IsEnd )
                _list.Remove( range );
            return index;
        }

        /// <summary>
        /// 添加索引
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="span">跨度</param>
        public void AddIndex( int index, int span = 1 ) {
            foreach ( var range in _list ) {
                if ( range.Contains( index ) ) {
                    AddIndex( range, index, span );
                    return;
                }
            }
        }

        /// <summary>
        /// 添加索引
        /// </summary>
        private void AddIndex( IndexRange range, int index, int span ) {
            var newRange = range.Split( index, span );
            if ( newRange == null )
                return;
            _list.Add( newRange );
        }
    }
}
