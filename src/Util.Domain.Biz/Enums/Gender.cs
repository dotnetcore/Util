using System.ComponentModel;

namespace Util.Domain.Biz.Enums {
    /// <summary>
    /// 性别
    /// </summary>
    public enum Gender {
        /// <summary>
        /// 女
        /// </summary>        
        [Description( "util.female" )]
        Female = 1,
        /// <summary>
        /// 男
        /// </summary>
        [Description( "util.male" )]
        Male = 2
    }
}
