using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Util.Helpers;

namespace Util.Datas.Queries.Trees {
    /// <summary>
    /// 树型查询参数
    /// </summary>
    public class TreeQueryParameter<TParentId> : QueryParameter, ITreeQueryParameter<TParentId> {
        /// <summary>
        /// 初始化树型查询参数
        /// </summary>
        protected TreeQueryParameter() {
            Order = "SortId";
        }

        /// <summary>
        /// 父编号
        /// </summary>
        public TParentId ParentId { get; set; }

        /// <summary>
        /// 级数
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
            return items.All( t => Ignore( t.Text, t.Value ) ) == false;
        }

        /// <summary>
        /// 忽略
        /// </summary>
        private bool Ignore( string name, object value ) {
            if ( value.SafeString().IsEmpty() )
                return true;
            switch ( name.SafeString().ToLower() ) {
                case "order":
                case "pagesize":
                case "page":
                case "totalcount":
                    return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 树型查询参数
    /// </summary>
    public class TreeQueryParameter : TreeQueryParameter<Guid?>, ITreeQueryParameter {
    }
}
