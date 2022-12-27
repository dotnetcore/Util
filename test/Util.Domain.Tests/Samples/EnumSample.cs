using System.ComponentModel;

namespace Util.Domain.Tests.Samples {
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
}
