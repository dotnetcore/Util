using System.ComponentModel.DataAnnotations;
using Util.Ui;

namespace Util.Data.Queries {
    /// <summary>
    /// 查询参数
    /// </summary>
    [Model( "queryParam" )]
    public class QueryParameter : Pager {
        /// <summary>
        /// 搜索关键字
        /// </summary>
        [Display( Name = "util.keyword" )]
        public string Keyword { get; set; }
    }
}
