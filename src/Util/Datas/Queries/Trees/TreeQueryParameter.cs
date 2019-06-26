using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Util.Helpers;

namespace Util.Datas.Queries.Trees {
    /// <summary>
    /// 树形查询参数
    /// </summary>
    public class TreeQueryParameter : TreeQueryParameter<Guid?>, ITreeQueryParameter {
    }

    /// <summary>
    /// 树形查询参数
    /// </summary>
    public class TreeQueryParameter<TParentId> : QueryParameter, ITreeQueryParameter<TParentId> {
        /// <summary>
        /// 初始化树形查询参数
        /// </summary>
        protected TreeQueryParameter() {
            Order = "SortId";
        }

        /// <summary>
        /// 父编号
        /// </summary>
        public TParentId ParentId { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int? Level { get; set; }

        private string _path = string.Empty;
        /// <summary>
        /// 路径
        /// </summary>
        public string Path {
            get => _path == null ? string.Empty : _path.Trim();
            set => _path = value;
        }

        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "启用" )]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 是否搜索
        /// </summary>
        public virtual bool IsSearch() {
            var items = Reflection.GetPublicProperties( this );
            return items.Any( t => IsSearchProperty( t.Text, t.Value ) );
        }

        /// <summary>
        /// 是否搜索属性
        /// </summary>
        protected virtual bool IsSearchProperty( string name, object value ) {
            if ( value.SafeString().IsEmpty() )
                return false;
            switch ( name.SafeString().ToLower() ) {
                case "order":
                case "pagesize":
                case "page":
                case "totalcount":
                    return false;
            }
            return true;
        }
    }
}
