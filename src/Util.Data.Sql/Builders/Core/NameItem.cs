using System;

namespace Util.Data.Sql.Builders.Core {
    /// <summary>
    /// 名称项,用于拆分列名或表名
    /// </summary>
    public class NameItem {
        /// <summary>
        /// 初始化名称项
        /// </summary>
        /// <param name="name">名称</param>
        public NameItem( string name ) {
            Resolve( name );
        }

        /// <summary>
        /// 解析
        /// </summary>
        private void Resolve( string name ) {
            name = Filter( name );
            var asItem = new SplitItem( name );
            Alias = asItem.Right;
            var dotItem = new SplitItem( asItem.Left, "." );
            if( dotItem.Right.IsEmpty() ) {
                Name = dotItem.Left;
                return;
            }
            Prefix = dotItem.Left;
            Name = dotItem.Right;
        }

        /// <summary>
        /// 过滤
        /// </summary>
        private string Filter( string name ) {
            name = FilterAs( name );
            return FilterDotSpace( name );
        }

        /// <summary>
        /// 过滤as关键字,替换为空格
        /// </summary>
        private string FilterAs( string name ) {
            return name.Replace( " as ", " ",StringComparison.OrdinalIgnoreCase );
        }

        /// <summary>
        /// 过滤.前后空格
        /// </summary>
        private string FilterDotSpace( string name ) {
            return name.Replace( @" .", "." ).Replace( @". ", "." );
        }

        /// <summary>
        /// 前缀，范例:a.b As c，值为 a
        /// </summary>
        public string Prefix { get; private set; }

        /// <summary>
        /// 名称，范例:a.b As c，值为 b
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 别名，范例:a.b As c，值为 c
        /// </summary>
        public string Alias { get; private set; }
    }
}
