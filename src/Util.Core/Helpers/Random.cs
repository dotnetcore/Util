using System.Collections.Generic;
using System.Linq;

namespace Util.Helpers {
    /// <summary>
    /// 随机数操作
    /// </summary>
    public class Random {
        /// <summary>
        /// 随机数
        /// </summary>
        private readonly System.Random _random;

        /// <summary>
        /// 初始化随机数
        /// </summary>
        public Random() {
            _random = new System.Random();
        }

        /// <summary>
        /// 获取指定范围的随机整数
        /// </summary>
        /// <param name="max">最大值</param>
        public int Next( int max ) {
            return _random.Next( max );
        }

        /// <summary>
        /// 获取指定范围的随机整数，该范围包括最小值，但不包括最大值
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        public int Next( int min, int max ) {
            return _random.Next( min, max );
        }

        /// <summary>
        /// 从集合中随机获取值
        /// </summary>
        /// <param name="array">集合</param>
        public static T GetValue<T>( IEnumerable<T> array ) {
            if ( array == null )
                return default;
            var random = new System.Random();
            var list = array.ToList();
            var index = random.Next( 0, list.Count );
            return list[index];
        }

        /// <summary>
        /// 对集合随机排序
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="array">集合</param>
        public static List<T> Sort<T>( IEnumerable<T> array ) {
            if( array == null )
                return null;
            var random = new System.Random();
            var list = array.ToList();
            for( int i = 0; i < list.Count; i++ ) {
                int index1 = random.Next( 0, list.Count );
                int index2 = random.Next( 0, list.Count );
                ( list[index1], list[index2] ) = ( list[index2], list[index1] );
            }
            return list;
        }
    }
}
