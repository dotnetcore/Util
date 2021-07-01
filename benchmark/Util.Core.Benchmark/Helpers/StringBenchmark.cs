using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Util.Helpers {
    /// <summary>
    /// 字符串操作性能测试
    /// </summary>
    [MemoryDiagnoser]
    public class StringBenchmark {
        /// <summary>
        /// 测试值
        /// </summary>
        private const string Value = "AbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefgAbcdefg";

        /// <summary>
        /// 测试将集合连接为带分隔符的字符串
        /// </summary>
        [Benchmark]
        public void Join() {
            Util.Helpers.String.Join( new List<int> { 1, 2, 3 }, "'" );
        }

        /// <summary>
        /// 测试首字母小写
        /// </summary>
        [Benchmark]
        public void FirstLowerCase() {
            Util.Helpers.String.FirstLowerCase( Value );
        }

        /// <summary>
        /// 测试首字母大写
        /// </summary>
        [Benchmark]
        public void FirstUpperCase() {
            Util.Helpers.String.FirstUpperCase( Value );
        }

        /// <summary>
        /// 测试移除起始字符串
        /// </summary>
        [Benchmark]
        public void RemoveStart() {
            Util.Helpers.String.RemoveStart( Value, "Ab" );
        }

        /// <summary>
        /// 测试移除末尾字符串
        /// </summary>
        [Benchmark]
        public void RemoveEnd() {
            Util.Helpers.String.RemoveEnd( Value, "efg" );
        }

        /// <summary>
        /// 测试移除起始字符串
        /// </summary>
        [Benchmark]
        public void RemoveStart_StringBuilder() {
            var value = new StringBuilder();
            value.Append( Value );
            Util.Helpers.String.RemoveStart( value, "Ab" );
        }

        /// <summary>
        /// 测试移除末尾字符串
        /// </summary>
        [Benchmark]
        public void RemoveEnd_StringBuilder() {
            var value = new StringBuilder();
            value.Append( Value );
            Util.Helpers.String.RemoveEnd( value, "efg" );
        }
    }
}
