using System.ComponentModel;

namespace Util.Tests.Samples {
    /// <summary>
    /// 枚举测试样例
    /// </summary>
    public enum EnumSample {
        A = 1,
        [Description( "B2" )]
        B = 2,
        [Description( "C3" )]
        C = 3,
        [Description( "D4" )]
        D = 4,
        [Description( "E5" )]
        E = 5
    }

    /// <summary>
    /// 枚举测试样例2
    /// </summary>
    public enum HttpMethod : byte {
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        Get = 0,
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        Put = 1,
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        Delete = 2,
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        Post = 3,
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        Head = 4,
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        Trace = 5,
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        Patch = 6,
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        Connect = 7,
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        Options = 8,
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        Custom = 9,
        /// <summary>
        /// This API supports framework infrastructure and is not intended to be used
        /// directly from application code.
        /// </summary>
        None = 255, // 0xFF
    }
}
