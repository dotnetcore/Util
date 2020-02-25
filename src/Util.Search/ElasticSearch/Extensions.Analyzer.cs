using Nest;

namespace Util.Search.ElasticSearch {
    /// <summary>
    /// ElasticSearch分析器扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置分析器为ik_max_word,设置搜索分析器为ik_smart
        /// </summary>
        /// <param name="source">文本属性</param>
        public static TextPropertyDescriptor<T> IkAnalyzer<T>( this TextPropertyDescriptor<T> source ) where T : class {
            return source.MaxWordAnalyzer().SmartSearchAnalyzer();
        }

        /// <summary>
        /// 设置分析器为ik_max_word
        /// </summary>
        /// <param name="source">文本属性</param>
        public static TextPropertyDescriptor<T> MaxWordAnalyzer<T>( this TextPropertyDescriptor<T> source ) where T : class {
            return source.Analyzer( "ik_max_word" );
        }

        /// <summary>
        /// 设置搜索分析器为ik_smart
        /// </summary>
        /// <param name="source">文本属性</param>
        public static TextPropertyDescriptor<T> SmartSearchAnalyzer<T>( this TextPropertyDescriptor<T> source ) where T : class {
            return source.SearchAnalyzer( "ik_smart" );
        }
    }
}
