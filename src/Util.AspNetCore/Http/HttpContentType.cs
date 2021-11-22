using System.ComponentModel;

namespace Util.Http {
    /// <summary>
    /// 内容类型
    /// </summary>
    public enum HttpContentType {
        /// <summary>
        /// application/x-www-form-urlencoded
        /// </summary>
        [Description( "application/x-www-form-urlencoded" )]
        FormUrlEncoded,
        /// <summary>
        /// application/json
        /// </summary>
        [Description( "application/json" )]
        Json,
        /// <summary>
        /// text/xml
        /// </summary>
        [Description( "text/xml" )]
        Xml
    }
}
