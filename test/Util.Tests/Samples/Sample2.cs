using System.ComponentModel;

namespace Util.Tests.Samples {
    /// <summary>
    /// 测试样例2
    /// </summary>
    [DisplayName( "测试样例2" )]
    public class Sample2 {
        /// <summary>
        /// string值
        /// </summary>
        public string StringValue { get; set; }
        /// <summary>
        /// int值
        /// </summary>
        public int IntValue { get; set; }
        /// <summary>
        /// 导航属性
        /// </summary>
        public Sample3 Test3 { get; set; }
    }
}
